using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfkitapYazariRepository : IkitapYazariRepository
    {
        public IQueryable<kitapYazari> kitapYazarlari => _context.kitapYazarlari;
        private libraryDBContext _context;
        public EfkitapYazariRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AddkitapYazariAsync(kitapYazari kitapYazari1)
        {
            _context.kitapYazarlari.Add(kitapYazari1);
            await _context.SaveChangesAsync();
        }

        public async Task DeletekitapYazariAsync(kitapYazari kitapYazari1)
        {
            _context.kitapYazarlari.Remove(kitapYazari1);
            await _context.SaveChangesAsync();
        }

        public async Task<kitapYazari?> GetkitapYazariByIdAsync(int id)
        {
            return await kitapYazarlari.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdatekitapYazariAsync(kitapYazari kitapYazari1)
        {
            _context.kitapYazarlari.Update(kitapYazari1);
            await _context.SaveChangesAsync();
        }
    }
}