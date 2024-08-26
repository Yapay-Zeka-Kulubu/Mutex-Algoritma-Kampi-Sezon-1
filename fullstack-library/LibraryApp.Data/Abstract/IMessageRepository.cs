using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract;

public interface IMessageRepository
{
    public IQueryable<Message> Messages { get; }

    public List<Message> GetMessagesByReceiverId(int receiverId);
    public void CreateMessage(Message msg);
    public void UpdateMessage(Message msg);

    //to see sent messages
    // public void GetMessagesBySenderId(int senderId);
}