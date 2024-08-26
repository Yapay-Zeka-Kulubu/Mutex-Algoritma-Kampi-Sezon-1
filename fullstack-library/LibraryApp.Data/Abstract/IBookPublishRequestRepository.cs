using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IBookPublishRequestRepository
    {
        IQueryable<BookPublishRequest> Requests { get; }

        void CreateRequest(BookPublishRequest bpr);
        Task UpdateRequest(BookPublishRequest bpr);
        void DeleteRequest(BookPublishRequest bpr);

    }
}