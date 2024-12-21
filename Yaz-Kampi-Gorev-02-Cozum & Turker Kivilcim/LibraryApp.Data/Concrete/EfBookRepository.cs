using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Concrete
{
    public class EfBookRepository : IBookRepository
    {
        public IQueryable<Book> Books => _context.Books;
        private LibraryDbContext _context;

        public EfBookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}