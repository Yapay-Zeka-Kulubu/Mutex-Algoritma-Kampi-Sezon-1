using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;
using LibraryApp.Data.Abstract;

namespace LibraryApp.Data.Concrete
{
    public class EfBookPublishRequestRepository : IBookPublishRequestRepository
    {
        public IQueryable<BookPublishRequest> Requests => _context.BookPublishRequests;
        LibraryDbContext _context;

        public EfBookPublishRequestRepository(LibraryDbContext libraryDbContext)
        {
            _context = libraryDbContext;
        }

        public async Task CreateRequestAsync(BookPublishRequest bpr)
        {
            _context.BookPublishRequests.Add(bpr);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRequestAsync(BookPublishRequest bpr)
        {
            _context.BookPublishRequests.Update(bpr);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestAsync(BookPublishRequest bpr)
        {
            _context.BookPublishRequests.Remove(bpr);
            await _context.SaveChangesAsync();
        }

    }
}