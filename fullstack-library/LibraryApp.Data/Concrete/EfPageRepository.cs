using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

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

        public void CreatePage(Page page)
        {
            _context.Pages.Add(page);
            _context.SaveChanges();
        }

        public void GetPages()
        {
            throw new NotImplementedException();
        }

        public void GetPageById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePage(Page page)
        {
            throw new NotImplementedException();
        }

        public void DeletePage(Page page)
        {
            throw new NotImplementedException();
        }
    }
}