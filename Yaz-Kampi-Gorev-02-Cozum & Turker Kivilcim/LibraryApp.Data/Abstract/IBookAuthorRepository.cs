using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IBookAuthorRepository
    {
        IQueryable<BookAuthor> BookAuthors { get; }

        Task<BookAuthor?> GetBookAuthorByIdAsync(int id);
        Task CreateBookAuthorAsync(BookAuthor bookAuthor);
        Task UpdateBookAuthorAsync(BookAuthor bookAuthor);
        Task DeleteBookAuthorAsync(BookAuthor bookAuthor);
    }
}