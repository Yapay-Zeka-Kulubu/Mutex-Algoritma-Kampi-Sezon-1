using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfuserRepository : IuserRepository
    {
        public IQueryable<user> users => _context.users;
        private libraryDBContext _context;
        public EfuserRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AdduserAsync(user user1)
        {
            _context.users.Add(user1);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteuserAsync(user user1)
        {
            _context.users.Remove(user1);
            await _context.SaveChangesAsync();
        }

        public async Task<user?> GetuserByIdAsync(int id)
        {
            return await users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateuserAsync(user user1)
        {
            _context.users.Update(user1);
            await _context.SaveChangesAsync();
        }
    }
}
