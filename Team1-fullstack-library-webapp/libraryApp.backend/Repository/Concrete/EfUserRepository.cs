using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfUserRepository : IUserRepository
    {
       
        public IQueryable<User> GetAllUsersAsync => _context.Users;

        private readonly LibraryDbContext _context;
        public EfUserRepository(LibraryDbContext context)
        {
            _context = context;
        }


        public async Task CreateUserAsync(User user)
        {

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async  Task DeleteUserAsync(int id)
        {
            var efUser = _context.Users.FindAsync(id);
            if (efUser != null)
            {
                _context.Remove(efUser);
                await _context.SaveChangesAsync();

            }
            else
                throw new ArgumentException("User doesn't found.");
            
        }

        public async Task UpdateUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUseridAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
