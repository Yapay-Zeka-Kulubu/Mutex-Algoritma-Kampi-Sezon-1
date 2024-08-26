using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IPageRepository
    {
        IQueryable<Page> Pages { get; }
        void GetPages();
        void GetPageById(int id);
        void CreatePage(Page page);
        void UpdatePage(Page page);
        void DeletePage(Page page);
    }
}