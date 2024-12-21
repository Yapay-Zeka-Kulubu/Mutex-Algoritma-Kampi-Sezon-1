using AutoMapper;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfBookPublishRequestRepository : IBookPublishRequestRepository
    {
        private readonly LibraryDbContext _context;

        public EfBookPublishRequestRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public IQueryable<BookPublishRequest> GetAllBookPublishRequests => _context.BookPublishRequests;

        public async Task<BookPublishRequest> GetBookPublishRequestById(int id)
        {
            return await _context.BookPublishRequests.FirstOrDefaultAsync(r => r.id == id);
        }

        public async Task AddBookPublishRequest(BookPublishRequest bookPublishRequest)
        {
            if (bookPublishRequest == null)
            {
                throw new ArgumentNullException(nameof(bookPublishRequest));
            }
            await _context.BookPublishRequests.AddAsync(bookPublishRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPublishRequest(BookPublishRequest bookPublishRequest)
        {
            if (bookPublishRequest == null)
            {
                throw new ArgumentNullException(nameof(bookPublishRequest));
            }
            _context.BookPublishRequests.Update(bookPublishRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookPublishRequestBy(int id)
        {
            var request = await _context.BookPublishRequests.FirstOrDefaultAsync(r => r.id == id);
            if (request != null)
            {
                _context.BookPublishRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Book publish request not found");
            }
        }
    }
}
