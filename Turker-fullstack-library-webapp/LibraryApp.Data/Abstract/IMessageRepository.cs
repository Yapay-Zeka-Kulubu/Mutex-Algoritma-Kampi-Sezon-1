using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract;

public interface IMessageRepository
{
    public IQueryable<Message> Messages { get; }

    public Task<List<Message>> GetMessagesByReceiverIdAsync(int receiverId);
    public Task CreateMessageAsync(Message msg);
    public Task UpdateMessageAsync(Message msg);
    public Task DeleteMessageAsync(Message msg);
}