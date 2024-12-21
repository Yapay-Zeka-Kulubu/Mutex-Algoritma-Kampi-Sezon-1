using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfkitapYayinTalebiRepository : IkitapYayinTalebiRepository
    {
        public IQueryable<kitapYayinTalebi> kitapYayinTalepleri => _context.kitapYayinTalepleri;
        private libraryDBContext _context;
        public EfkitapYayinTalebiRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AddkitapYayinTalebiAsync(kitapYayinTalebi kitapYayinTalebi1)
        {
            _context.kitapYayinTalepleri.Add(kitapYayinTalebi1);
            await _context.SaveChangesAsync();
        }

        public async Task DeletekitapYayinTalebiAsync(kitapYayinTalebi kitapYayinTalebi1)
        {
            _context.kitapYayinTalepleri.Remove(kitapYayinTalebi1);
            await _context.SaveChangesAsync();
        }

        public async Task<kitapYayinTalebi?> GetkitapYayinTalebiByIdAsync(int id)
        {
            return await kitapYayinTalepleri.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdatekitapYayinTalebiAsync(kitapYayinTalebi kitapYayinTalebi1)
        {
            _context.kitapYayinTalepleri.Update(kitapYayinTalebi1);
            await _context.SaveChangesAsync();
        }
    }
}