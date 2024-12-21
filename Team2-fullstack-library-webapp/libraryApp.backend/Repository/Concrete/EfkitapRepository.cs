using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfkitapRepository : IkitapRepository
    {
        public IQueryable<kitap> kitaplar => _context.kitaplar;
        private libraryDBContext _context;
        public EfkitapRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AddkitapAsync(kitap kitap1)
        {
            _context.kitaplar.Add(kitap1);
            await _context.SaveChangesAsync();
        }

        public async Task DeletekitapAsync(kitap kitap1)
        {
            _context.kitaplar.Remove(kitap1);
            await _context.SaveChangesAsync();
        }

        public async Task<kitap?> GetkitapByIdAsync(int id)
        {
            return await kitaplar.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdatekitapAsync(kitap kitap1)
        {
            _context.kitaplar.Update(kitap1);
            await _context.SaveChangesAsync();
        }
    }
}