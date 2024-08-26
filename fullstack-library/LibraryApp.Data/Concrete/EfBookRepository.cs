using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

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

        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public IQueryable<Book> GetBooks()
        {
            return Books;
        }

        public Book? GetBookById(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}