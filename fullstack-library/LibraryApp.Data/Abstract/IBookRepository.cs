using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        IQueryable<Book> GetBooks();
        Book? GetBookById(int id);
        void CreateBook(Book book);
        Task UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}