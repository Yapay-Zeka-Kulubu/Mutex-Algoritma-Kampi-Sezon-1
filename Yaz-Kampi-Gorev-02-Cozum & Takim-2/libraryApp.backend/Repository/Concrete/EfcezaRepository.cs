using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfcezaRepository : IcezaRepository
    {
        public IQueryable<ceza> cezalar => _context.cezalar;
        private libraryDBContext _context;
        public EfcezaRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AddcezaAsync(ceza ceza1)
        {
            _context.cezalar.Add(ceza1);
            await _context.SaveChangesAsync();
        }

        public async Task DeletecezaAsync(ceza ceza1)
        {
            _context.cezalar.Remove(ceza1);
            await _context.SaveChangesAsync();
        }

        public async Task<ceza?> GetcezaByIdAsync(int id)
        {
            return await cezalar.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdatecezaAsync(ceza ceza1)
        {
            _context.cezalar.Update(ceza1);
            await _context.SaveChangesAsync();
        }
    }
}