using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Concrete
{
    public class EfBookAuthorRepository : IBookAuthorRepository
    {
        public IQueryable<BookAuthor> BookAuthors => _context.BookAuthors;
        private LibraryDbContext _context;

        public EfBookAuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        //TODO adding more author
        public async Task<BookAuthor?> GetBookAuthorByIdAsync(int id)
        {
            return await _context.BookAuthors.FirstOrDefaultAsync(ba => ba.Id == id);
        }

        public async Task CreateBookAuthorAsync(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Add(bookAuthor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAuthorAsync(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Update(bookAuthor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAuthorAsync(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Remove(bookAuthor);
            await _context.SaveChangesAsync();
        }
    }
}