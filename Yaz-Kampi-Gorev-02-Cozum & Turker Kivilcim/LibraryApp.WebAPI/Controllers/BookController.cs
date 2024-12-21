using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using LibraryApp.WebAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fullstack_library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;
        private readonly IPageRepository _pageRepo;
        private readonly IBookBorrowActivityRepository _bookBorrowRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMessageRepository _msgRepo;
        private readonly IBookPublishRequestRepository _bookPublishReqsRepo;

        public BookController(IBookRepository bookRepo, IBookBorrowActivityRepository bookBorrowRepo, IUserRepository userRepo, IBookPublishRequestRepository bookPublishRequestRepository, IPageRepository pageRepository, IMessageRepository messageRepository)
        {
            _bookRepo = bookRepo;
            _bookBorrowRepo = bookBorrowRepo;
            _userRepo = userRepo;
            _bookPublishReqsRepo = bookPublishRequestRepository;
            _pageRepo = pageRepository;
            _msgRepo = messageRepository;
        }

        [HttpPut("SetPublishing")]
        [Authorize(Policy = "ManagerPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> SetPublishing(PublishBookDTO publishBookDTO)
        {
            //get request and manager
            var request = _bookPublishReqsRepo.Requests.Include(bpr => bpr.Book).ThenInclude(b => b.BookAuthors).FirstOrDefault(bpr => bpr.Id == publishBookDTO.RequestId);
            if (request == null) return NotFound(new { Message = "Request not found." });
            if (!request.IsPending) return BadRequest(new { Message = "You already did operations with this request." });
            var manager = await _userRepo.GetUserByIdAsync(publishBookDTO.ManagerId);
            if (manager == null) return NotFound(new { Message = "Manager not found" });

            //update manager's score depends on response delay
            manager.MonthlyScore += request.RequestDate.AddDays(SettingsHelper.AllowedDelayForResponses) >= DateTime.UtcNow ? 1 : -1;

            //update book
            if (publishBookDTO.IsApproved)
            {
                request.Book.IsPublished = true;
                request.Book.PublishDate = DateTime.UtcNow;
                await _bookRepo.UpdateBookAsync(request.Book);
            }

            //send automatic message to all authors of the book about response
            string msgToSend = !string.IsNullOrEmpty(publishBookDTO.Details) ? publishBookDTO.Details : publishBookDTO.IsApproved ? "Your book publishment request is approved." : "Your book publishment request is rejected.";
            foreach (var ba in request.Book.BookAuthors)
            {
                await _msgRepo.CreateMessageAsync(new Message
                {
                    Title = "About your book publishment request",
                    Details = msgToSend,
                    ReceiverId = ba.UserId,
                    SenderId = publishBookDTO.ManagerId
                });
            }

            //set request as handled
            request.IsPending = false;
            await _bookPublishReqsRepo.UpdateRequestAsync(request);

            return Ok(new { message = publishBookDTO.IsApproved ? "Request approved." : "Request rejected." });
        }

        [HttpGet("BookPublishRequests")]
        [Authorize(Policy = "ManagerPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> BookPublishRequests()
        {
            //get publishing requests
            var BookPublishRequests = await _bookPublishReqsRepo.Requests.Where(bpr => bpr.IsPending).Include(bpr => bpr.Book).ThenInclude(b => b.BookAuthors).ThenInclude(ba => ba.User).OrderBy(bpr => bpr.RequestDate).ToListAsync();
            return Ok(BookPublishRequests.Select(bpr => new BookPublishReqDTO
            {
                Authors = bpr.Book.BookAuthors.Select(ba => ba.User.Name).ToList(),
                BookName = bpr.Book.Title,
                BookId = bpr.Book.Id,
                Id = bpr.Id,
                RequestDate = bpr.RequestDate,
            }));
        }

        [HttpPost("RequestPublishment")]
        [Authorize(Policy = "AuthorPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> RequestPublishment([FromBody] int bookId)
        {
            //get book
            var book = await _bookRepo.GetBookByIdAsync(bookId);
            if (book == null) return NotFound(new { Message = "Book not found." });
            if (book.IsPublished) return BadRequest(new { Message = "Your book is already published." });
            if (_bookPublishReqsRepo.Requests.Any(bpr => bpr.IsPending && bpr.BookId == bookId))
                return BadRequest(new { Message = "Your request is still active." });

            //create request
            await _bookPublishReqsRepo.CreateRequestAsync(new BookPublishRequest()
            {
                BookId = bookId,
                IsPending = true,
                RequestDate = DateTime.UtcNow,
            });
            return Ok(new { Message = "Request has sent" });
        }

        [HttpGet("SearchBook")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> SearchBook([FromQuery] string? bookName)
        {
            //get filtered books
            var books = await _bookRepo.Books.Where(b => b.Title.Contains(bookName ?? "") && b.IsPublished).OrderBy(b => b.Title).Take(20).Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                IsBorrowed = b.IsBorrowed,
                Authors = b.BookAuthors.Select(ba => ba.User.Name).ToList(),
                PublishDate = b.PublishDate,
            }).ToListAsync();
            return Ok(books);
        }

        [HttpGet("BorrowedBooks")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> BorrowedBooks([FromQuery] int userId)
        {
            //get user's borrowed books
            var borrowedBookDTOS = await _bookBorrowRepo.BookBorrowActivities.Where(bba => bba.UserId == userId && bba.IsApproved && !bba.IsReturned).Include(bba => bba.Book).OrderBy(b => b.Book.Title).Select(bba => new BookBorrowActivityDTO
            {
                BorrowDate = bba.BorrowDate,
                ReturnDate = bba.ReturnDate,
                BookDTO = new BookDTO
                {
                    Id = bba.BookId,
                    Authors = bba.Book.BookAuthors.Select(ba => ba.User.Name).ToList(),
                    Title = bba.Book.Title,
                    IsBorrowed = bba.Book.IsBorrowed,
                    PublishDate = bba.Book.PublishDate,
                },
            }).ToListAsync();

            return Ok(borrowedBookDTOS);
        }

        [HttpGet("BorrowRequests")]
        [Authorize(Policy = "StaffOrManagerPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> BorrowRequests()
        {
            //get borrow requests
            var borrowedBookDTOS = await _bookBorrowRepo.BookBorrowActivities.Where(bba => !bba.IsApproved).Include(bba => bba.Book).Include(bba => bba.User).OrderBy(bba => bba.BorrowDate).Select(bba => new BookBorrowActivityDTO
            {
                Id = bba.Id,
                RequestorName = bba.User.Name + " " + bba.User.Surname,
                BorrowDate = bba.BorrowDate,
                ReturnDate = bba.ReturnDate,
                BookDTO = new BookDTO
                {
                    Title = bba.Book.Title,
                },
            }).ToListAsync();

            return Ok(borrowedBookDTOS);
        }

        [HttpPost("SetBorrowRequest")]
        [Authorize(Policy = "StaffOrManagerPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> SetBorrowRequest(SetBorrowRequestDTO setBorrowRequestDTO)
        {
            //get borrow request
            var bookBorrowActivity = _bookBorrowRepo.BookBorrowActivities.Include(bba => bba.Book).FirstOrDefault(bba => bba.Id == setBorrowRequestDTO.Id);
            if (bookBorrowActivity == null) return NotFound(new { Message = "Borrow request not found." });
            if (bookBorrowActivity.IsApproved) return BadRequest(new { Message = "You already did operations with this request." });

            //get staff
            var staff = await _userRepo.GetUserByIdAsync(setBorrowRequestDTO.StaffId);
            if (staff == null) return NotFound(new { Message = "Staff not found" });

            //update staffs score depending on response delay
            staff.MonthlyScore += bookBorrowActivity.BorrowDate.AddDays(SettingsHelper.AllowedDelayForResponses) >= DateTime.UtcNow ? 1 : -1;

            //update request
            if (setBorrowRequestDTO.IsApproved)
            {
                bookBorrowActivity.IsApproved = true;
                bookBorrowActivity.Book.IsBorrowed = true;

                //add more days to return date if staff responded late
                TimeSpan responseDelay = DateTime.UtcNow - bookBorrowActivity.BorrowDate;
                bookBorrowActivity.BorrowDate = DateTime.UtcNow;
                bookBorrowActivity.ReturnDate = bookBorrowActivity.ReturnDate.AddDays(Math.Abs(responseDelay.Days));
                await _bookBorrowRepo.UpdateBookBorrowActivityAsync(bookBorrowActivity);

                //delete other waiting requests for same book
                var sameBookRequests = _bookBorrowRepo.BookBorrowActivities.Where(bba => !bba.IsApproved && bba.BookId == bookBorrowActivity.BookId && bba.Id != bookBorrowActivity.Id).ToList();
                await _bookBorrowRepo.DeleteBookBorrowActivitiesAsync(sameBookRequests);
            }
            else
                await _bookBorrowRepo.DeleteBookBorrowActivityAsync(bookBorrowActivity);

            //send automatic message to borrower about the situation
            string msgToSend = !String.IsNullOrEmpty(setBorrowRequestDTO.Details) ? setBorrowRequestDTO.Details : setBorrowRequestDTO.IsApproved ? "Your book borrow request is approved." : "Your book borrow request is rejected.";
            await _msgRepo.CreateMessageAsync(new Message
            {
                Title = "About your book borrow request",
                Details = msgToSend,
                ReceiverId = bookBorrowActivity.UserId,
                SenderId = setBorrowRequestDTO.StaffId
            });

            return Ok(new { Message = setBorrowRequestDTO.IsApproved ? "Request approved." : "Request rejected" });
        }

        [HttpPost("BorrowBook")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> BorrowBook(BorrowBookDTO borrowBookDTO)
        {
            //get user and book
            var user = await _userRepo.GetUserByIdAsync(borrowBookDTO.UserId);
            if (user == null) return NotFound(new { Message = "User could not found" });
            var book = await _bookRepo.GetBookByIdAsync(borrowBookDTO.BookId);
            if (book == null) return NotFound(new { Message = "Book could not found" });
            if (book.IsBorrowed) return BadRequest(new { Message = "Book already borrowed" });

            if (_bookBorrowRepo.BookBorrowActivities.Any(bba => !bba.IsApproved && bba.BookId == borrowBookDTO.BookId && bba.UserId == borrowBookDTO.UserId)) return BadRequest(new { Message = "You already requested that book. Please wait for approval." });

            //create a request
            BookBorrowActivity bba = new()
            {
                BookId = borrowBookDTO.BookId,
                UserId = borrowBookDTO.UserId,
                BorrowDate = DateTime.UtcNow,
                IsApproved = false,
                ReturnDate = DateTime.UtcNow.AddDays(user.MonthlyScore == 0 ? SettingsHelper.DefaultBorrowDuration : SettingsHelper.ExtraDurationForReturningFast),
            };
            await _bookBorrowRepo.CreateBookBorrowActivityAsync(bba);
            return Ok(new { Message = "Borrow request has sent to staff. Please wait for approval." });
        }

        [HttpGet("GetBook")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> GetBook([FromQuery] int bookId)
        {
            //to read book get by id
            var book = await _bookRepo.Books.Include(b => b.Pages).Include(b => b.BookBorrowActivities).Include(b => b.BookAuthors).FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null) return NotFound(new { Message = "Book not found" });
            return Ok(new ReadBookDTO
            {
                BorrowedById = book.BookBorrowActivities.FirstOrDefault(bba => bba.IsApproved && !bba.IsReturned)?.UserId ?? 0,
                Title = book.Title,
                IsPublished = book.IsPublished,
                AuthorIds = book.BookAuthors.Select(ba => ba.UserId).ToList(),
                Pages = book.Pages.Select(p => new PageDTO
                {
                    Content = p.Content,
                    PageNumber = p.PageNumber,
                    PageId = p.Id,
                }).ToList(),
            });
        }

        [HttpGet("GetBooksByAuthor")]
        [Authorize(Policy = "AuthorPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> GetBooksByAuthor([FromQuery] int userId)
        {
            //to see author's book
            if (!_userRepo.Users.Any(u => u.Id == userId)) return NotFound(new { Message = "User not found." });
            var books = await _bookRepo.Books
            .AsNoTracking()
            .Where(b => b.BookAuthors.Any(ba => ba.UserId == userId))
            .OrderBy(b => b.PublishDate)
            .ToListAsync();

            var MyBookDTOS = books.Select(b => new MyBooksDTO
            {
                BookId = b.Id,
                BookName = b.Title,
                PublishDate = b.PublishDate,
                Status = b.IsPublished ? "Published" : b.BookPublishRequests.Any(bpr => bpr.IsPending) ? "Waiting for approval" : "Can send request",
            });

            return Ok(MyBookDTOS);
        }

        [HttpPost("WritePage")]
        [Authorize(Policy = "AuthorPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> WritePage([FromBody] PageDTO pageDTO)
        {
            //get book
            var book = _bookRepo.Books.Include(b => b.Pages).FirstOrDefault(b => b.Id == pageDTO.BookId);
            if (book == null) return NotFound(new { Message = "Book not found." });
            if (book.IsPublished) return BadRequest(new { Message = "Cannot add page to published book" });
            if (book.Pages.Any(p => p.PageNumber == pageDTO.PageNumber)) return BadRequest(new { Message = "There is a page with that number." });

            //write page
            await _pageRepo.CreatePageAsync(new Page
            {
                BookId = pageDTO.BookId,
                Content = pageDTO.Content,
                PageNumber = pageDTO.PageNumber,
            });

            return Ok(new { Message = "Page saved." });
        }


        [HttpPut("EditPage")]
        [Authorize(Policy = "AuthorPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> EditPage([FromBody] PageDTO pageDTO)
        {
            //get book
            var book = await _bookRepo.GetBookByIdAsync(pageDTO.BookId);
            if (book == null) return NotFound(new { Message = "Book not found." });
            var page = await _pageRepo.GetPageByIdAsync(pageDTO.PageId);
            if (page == null) return NotFound(new { Message = "Page not found." });
            if (book.IsPublished) return BadRequest(new { Message = "Cannot edit page of published book" });

            //edit page
            page.Content = pageDTO.Content;
            await _pageRepo.UpdatePageAsync(page);
            return Ok(new { Message = "Page updated." });
        }

        [HttpPost("CreateBook")]
        [Authorize(Policy = "AuthorPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> CreateBook([FromBody] int authorId)
        {
            //get author & create book
            if (!_userRepo.Users.Any(u => u.Id == authorId)) return NotFound(new { Message = "Author not found." });
            await _bookRepo.CreateBookAsync(new Book
            {
                IsBorrowed = false,
                IsPublished = false,
                PublishDate = new DateTime(1000, 1, 1),
                Title = "New Book",
                BookAuthors = [
                    new BookAuthor(){
                        UserId = authorId,
                    }
                ]
            });
            return Ok(new { Message = "Book created" });
        }

        [HttpPost("CreateBookWithDetails")]
        [Authorize(Policy = "AuthorPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> CreateBookWithDetails([FromBody] CreateDetailedBookDTO detailedBookDTO)
        {
            if (!_userRepo.Users.Any(u => u.Id == detailedBookDTO.AuthorId)) return NotFound(new { Message = "Author not found." });
            await _bookRepo.CreateBookAsync(new Book
            {
                IsBorrowed = false,
                IsPublished = false,
                PublishDate = new DateTime(1000, 1, 1),
                Title = "New Book",
                BookAuthors = [
                    new BookAuthor{
                        UserId = detailedBookDTO.AuthorId,
                    }
                    ],

                    //replacing null chars with empty because npgsql does not allow these chars for utf8
                Pages = detailedBookDTO.Pages.Select(p => new Page { Content = p.Content.Replace("\0", ""), PageNumber = p.PageNumber }).ToList(),
            });
            return Ok(new { Message = "Detailed book created" });
        }

        [HttpPut("UpdateBookName")]
        [Authorize(Policy = "AuthorPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> UpdateBookName(MyBooksDTO myBooksDTO)
        {
            //get book and update title
            var book = _bookRepo.Books.FirstOrDefault(b => b.Id == myBooksDTO.BookId);
            if (book == null) return NotFound(new { Message = "Book not found." });
            if (book.IsPublished) return BadRequest(new { Message = "Cannot change name of published books." });

            book.Title = myBooksDTO.BookName;
            await _bookRepo.UpdateBookAsync(book);
            return Ok(new { Message = "Book Updated" });
        }

        [HttpPut("ReturnBook")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> ReturnBook([FromBody] int bookId)
        {
            //get book
            var book = _bookRepo.Books.Include(b => b.BookBorrowActivities).ThenInclude(bba => bba.User).FirstOrDefault(b => b.Id == bookId);
            if (book == null) return NotFound(new { Message = "Book not found." });

            //get borrow request
            var bba = book.BookBorrowActivities.FirstOrDefault(bba => bba.IsApproved && !bba.IsReturned);
            if (bba == null) return BadRequest(new { Message = "Borrow activity not found." });

            //update
            book.IsBorrowed = false;
            bba.IsReturned = true;

            //update user's score depending on if he returned early or not
            bba.User.MonthlyScore += bba.ReturnDate >= DateTime.UtcNow ? 1 : -bba.User.MonthlyScore;

            if (DateTime.UtcNow > bba.ReturnDate)
            {
                //if user returned late then punish it by giving fine and send automessage about it
                bba.User.IsPunished = true;
                bba.User.FineAmount = Math.Abs((DateTime.UtcNow - bba.ReturnDate).Days) * SettingsHelper.FinePerDay;
                await _msgRepo.CreateMessageAsync(new Message
                {
                    ReceiverId = bba.UserId,
                    Details = "You are punished from library by returning book late. Please pay your fine to re-open your account.",
                    SenderId = bba.UserId,
                    Title = "You are punished from library at " + DateTime.UtcNow,
                });
            }

            await _bookRepo.UpdateBookAsync(book);
            await _bookBorrowRepo.UpdateBookBorrowActivityAsync(bba);
            return Ok(new { Message = "Book returned." });
        }
    }
}