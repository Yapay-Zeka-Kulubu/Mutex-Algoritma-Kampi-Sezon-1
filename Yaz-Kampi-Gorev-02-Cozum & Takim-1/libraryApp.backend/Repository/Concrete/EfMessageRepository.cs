using AutoMapper;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfMessageRepository : IMessageRepository
    {
        private readonly LibraryDbContext _context;

        public EfMessageRepository(LibraryDbContext context)
        {
           _context = context;
        }
        public IQueryable<Message> GetAllMessages => _context.Messages;

        public async Task<Message> GetMessageById(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.id == id);
        }

        public async Task AddMessage(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMessage(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessage(int id)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(m => m.id == id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Message not found");
            }
        }
    }
}
