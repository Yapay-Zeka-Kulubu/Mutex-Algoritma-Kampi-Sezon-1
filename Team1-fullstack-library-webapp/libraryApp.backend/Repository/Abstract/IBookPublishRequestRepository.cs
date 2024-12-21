using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IBookPublishRequestRepository
    {
        IQueryable<BookPublishRequest> GetAllBookPublishRequests {  get; }
        Task<BookPublishRequest> GetBookPublishRequestById(int id);
        Task AddBookPublishRequest(BookPublishRequest bookPublishRequest);
        Task UpdateBookPublishRequest(BookPublishRequest bookPublishRequest);
        Task DeleteBookPublishRequestBy(int id);
    }
}
