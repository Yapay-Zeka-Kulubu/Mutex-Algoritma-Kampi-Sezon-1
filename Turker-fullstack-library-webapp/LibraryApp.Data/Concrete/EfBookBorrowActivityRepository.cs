using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Concrete
{
    public class EfBookBorrowActivityRepository : IBookBorrowActivityRepository
    {
        public IQueryable<BookBorrowActivity> BookBorrowActivities => _context.BookBorrowActivities;
        private LibraryDbContext _context;

        public EfBookBorrowActivityRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateBookBorrowActivityAsync(BookBorrowActivity bookBorrowActivity)
        {
            _context.BookBorrowActivities.Add(bookBorrowActivity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookBorrowActivityAsync(BookBorrowActivity bookBorrowActivity)
        {
            _context.BookBorrowActivities.Update(bookBorrowActivity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookBorrowActivitiesAsync(List<BookBorrowActivity> bookBorrowActivities)
        {
            _context.BookBorrowActivities.RemoveRange(bookBorrowActivities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookBorrowActivityAsync(BookBorrowActivity bookBorrowActivity)
        {
            _context.BookBorrowActivities.Remove(bookBorrowActivity);
            await _context.SaveChangesAsync();
        }
    }
}