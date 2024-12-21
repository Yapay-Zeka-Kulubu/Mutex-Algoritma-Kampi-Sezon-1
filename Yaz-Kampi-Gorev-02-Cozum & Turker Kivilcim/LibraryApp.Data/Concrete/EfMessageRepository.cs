using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Concrete
{
    public class EfMessageRepository : IMessageRepository
    {
        public IQueryable<Message> Messages => _context.Messages;
        private LibraryDbContext _context;

        public EfMessageRepository(LibraryDbContext libraryDbContext)
        {
            _context = libraryDbContext;
        }

        public async Task CreateMessageAsync(Message msg)
        {
            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetMessagesByReceiverIdAsync(int receiverId)
        {
            return await _context.Messages.Where(m => m.ReceiverId == receiverId).Include(m => m.Sender).ToListAsync();
        }

        public async Task UpdateMessageAsync(Message msg)
        {
            _context.Messages.Update(msg);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(Message msg)
        {
            _context.Messages.Remove(msg);
            await _context.SaveChangesAsync();
        }
    }
}