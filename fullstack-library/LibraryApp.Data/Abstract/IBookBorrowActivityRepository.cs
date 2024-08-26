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

        void CreateBookBorrowActivity(BookBorrowActivity bookBorrowActivity);
        Task UpdateBookBorrowActivity(BookBorrowActivity bookBorrowActivity);
        Task DeleteBookBorrowActivities(List<BookBorrowActivity> bookBorrowActivities);
        Task DeleteBookBorrowActivity(BookBorrowActivity bookBorrowActivity);
    }
}