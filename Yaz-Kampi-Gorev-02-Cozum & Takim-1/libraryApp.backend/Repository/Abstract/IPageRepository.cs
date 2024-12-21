using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IPageRepository
    {
        IQueryable<Page> GetAllPages {  get; }
        IQueryable<Page> GetAllPagesOfABook(Book book);
        Task<Page> GetPageById(int id);
        Task AddPage(Page page);
        Task UpdatePage(Page page);
        Task DeletePage(int id);

    }
}
