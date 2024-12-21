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

        Task CreateRequestAsync(BookPublishRequest bpr);
        Task UpdateRequestAsync(BookPublishRequest bpr);
        Task DeleteRequestAsync(BookPublishRequest bpr);

    }
}