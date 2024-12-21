using AutoMapper;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfPageRepository : IPageRepository
    {
        private readonly LibraryDbContext _context;

        public EfPageRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public IQueryable<Page> GetAllPages => _context.Pages;


        public async Task<Page> GetPageById(int id)
        {
            return await _context.Pages.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task AddPage(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }
            await _context.Pages.AddAsync(page);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePage(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }
            _context.Pages.Update(page);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePage(int id)
        {
            var page = await _context.Pages.FirstOrDefaultAsync(p => p.id == id);
            if (page != null)
            {
                _context.Pages.Remove(page);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Page not found");
            }
        }

        public IQueryable<Page> GetAllPagesOfABook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            return _context.Pages.Where(p => p.bookId == book.id);
        }
    }
}
