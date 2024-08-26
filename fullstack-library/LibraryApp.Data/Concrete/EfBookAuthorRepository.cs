using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

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

        public void CreateBookAuthor(BookAuthor bookAuthor)
        {
            throw new NotImplementedException();
        }

        public void GetBookAuthors()
        {
            throw new NotImplementedException();
        }

        public void GetBookAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookAuthor(BookAuthor bookAuthor)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookAuthor(BookAuthor bookAuthor)
        {
            throw new NotImplementedException();
        }
    }
}