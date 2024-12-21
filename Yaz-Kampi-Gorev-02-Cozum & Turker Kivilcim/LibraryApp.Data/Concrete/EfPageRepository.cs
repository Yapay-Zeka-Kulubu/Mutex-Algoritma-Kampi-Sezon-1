using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Concrete
{
    public class EfPageRepository : IPageRepository
    {
        public IQueryable<Page> Pages => _context.Pages;
        private LibraryDbContext _context;

        public EfPageRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreatePageAsync(Page page)
        {
            _context.Pages.Add(page);
            await _context.SaveChangesAsync();
        }

        public async Task<Page?> GetPageByIdAsync(int id)
        {
            return await _context.Pages.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdatePageAsync(Page page)
        {
            _context.Pages.Update(page);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePageAsync(Page page)
        {
            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();
        }
    }
}