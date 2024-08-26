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

        public void CreateMessage(Message msg)
        {
            _context.Messages.Add(msg);
            _context.SaveChanges();
        }

        //TODO Make every list returning method queryable returning method and delete getmethods as property is public 
        public List<Message> GetMessagesByReceiverId(int receiverId)
        {
            return _context.Messages.Where(m => m.ReceiverId == receiverId).Include(m => m.Sender).ToList();
        }

        public void UpdateMessage(Message msg){
            _context.Messages.Update(msg);
            _context.SaveChanges();
        }


        //to see sent messages
        // public void GetMessagesBySenderId(int senderId)
        // {
        //     throw new NotImplementedException();
        // }
    }
}