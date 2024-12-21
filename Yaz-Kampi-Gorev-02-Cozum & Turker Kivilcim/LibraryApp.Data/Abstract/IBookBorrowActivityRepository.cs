using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IBookBorrowActivityRepository
    {
        IQueryable<BookBorrowActivity> BookBorrowActivities { get; }

        Task CreateBookBorrowActivityAsync(BookBorrowActivity bookBorrowActivity);
        Task UpdateBookBorrowActivityAsync(BookBorrowActivity bookBorrowActivity);
        Task DeleteBookBorrowActivitiesAsync(List<BookBorrowActivity> bookBorrowActivities);
        Task DeleteBookBorrowActivityAsync(BookBorrowActivity bookBorrowActivity);
    }
}