using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetAllMessages {  get; }
        Task<Message> GetMessageById(int id);
        Task AddMessage(Message message);
        Task UpdateMessage(Message message);
        Task DeleteMessage(int id);
    }
}
