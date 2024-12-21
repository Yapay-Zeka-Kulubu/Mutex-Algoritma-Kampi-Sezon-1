using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfsayfaRepository : IsayfaRepository
    {
        public IQueryable<sayfa> sayfalar => _context.sayfalar;
        private libraryDBContext _context;
        public EfsayfaRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AddsayfaAsync(sayfa sayfa1)
        {
            _context.sayfalar.Add(sayfa1);
            await _context.SaveChangesAsync();
        }

        public async Task DeletesayfaAsync(sayfa sayfa1)
        {
            _context.sayfalar.Remove(sayfa1);
            await _context.SaveChangesAsync();
        }

        public async Task<sayfa?> GetsayfaByIdAsync(int id)
        {
            return await sayfalar.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdatesayfaAsync(sayfa sayfa1)
        {
            _context.sayfalar.Update(sayfa1);
            await _context.SaveChangesAsync();
        }
    }
}