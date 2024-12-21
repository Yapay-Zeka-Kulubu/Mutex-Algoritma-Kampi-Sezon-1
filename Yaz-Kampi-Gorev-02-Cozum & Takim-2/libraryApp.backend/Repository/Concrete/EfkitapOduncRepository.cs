using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfkitapOduncRepository : IkitapOduncRepository
    {
        public IQueryable<kitapOdunc> kitapOduncler => _context.kitapOduncler;
        private libraryDBContext _context;
        public EfkitapOduncRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AddkitapOduncAsync(kitapOdunc kitapOdunc1)
        {
            _context.kitapOduncler.Add(kitapOdunc1);
            await _context.SaveChangesAsync();
        }

        public async Task DeletekitapOduncAsync(kitapOdunc kitapOdunc1)
        {
            _context.kitapOduncler.Remove(kitapOdunc1);
            await _context.SaveChangesAsync();
        }

        public async Task<kitapOdunc?> GetkitapOduncByIdAsync(int id)
        {
            return await kitapOduncler.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdatekitapOduncAsync(kitapOdunc kitapOdunc1)
        {
            _context.kitapOduncler.Update(kitapOdunc1);
            await _context.SaveChangesAsync();
        }
    }
}