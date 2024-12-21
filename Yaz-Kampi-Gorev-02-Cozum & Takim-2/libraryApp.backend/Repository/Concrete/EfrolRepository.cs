using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfrolRepository : IrolRepository
    {
        public IQueryable<rol> roller => _context.roller;
        private libraryDBContext _context;
        public EfrolRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AddrolAsync(rol rol1)
        {
            _context.roller.Add(rol1);
            await _context.SaveChangesAsync();
        }

        public async Task DeleterolAsync(rol rol1)
        {
            _context.roller.Remove(rol1);
            await _context.SaveChangesAsync();
        }

        public async Task<rol?> GetrolByIdAsync(int id)
        {
            return await roller.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdaterolAsync(rol rol1)
        {
            _context.roller.Update(rol1);
            await _context.SaveChangesAsync();
        }
    }
}