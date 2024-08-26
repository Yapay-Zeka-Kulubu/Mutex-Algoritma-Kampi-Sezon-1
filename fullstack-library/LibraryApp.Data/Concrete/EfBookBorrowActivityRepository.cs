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

        public void CreateBookBorrowActivity(BookBorrowActivity bookBorrowActivity)
        {
            _context.BookBorrowActivities.Add(bookBorrowActivity);
            _context.SaveChanges();
        }

        public async Task UpdateBookBorrowActivity(BookBorrowActivity bookBorrowActivity)
        {
            _context.BookBorrowActivities.Update(bookBorrowActivity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookBorrowActivities(List<BookBorrowActivity> bookBorrowActivities)
        {
            _context.BookBorrowActivities.RemoveRange(bookBorrowActivities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookBorrowActivity(BookBorrowActivity bookBorrowActivity)
        {
            _context.BookBorrowActivities.Remove(bookBorrowActivity);
            await _context.SaveChangesAsync();
        }
    }
}