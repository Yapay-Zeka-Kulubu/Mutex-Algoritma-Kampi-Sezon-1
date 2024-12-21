using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks {  get; }
        Task<Book> GetBookById(int id);
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}
