using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfpuanRepository:IpuanRepository
    {
        public IQueryable<puan> puanlar => _context.puanlar;
        private libraryDBContext _context;
        public EfpuanRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AddpuanAsync(puan puan1)
        {
            _context.puanlar.Add(puan1);
            await _context.SaveChangesAsync();
        }

        public async Task DeletepuanAsync(puan puan1)
        {
            _context.puanlar.Remove(puan1);
            await _context.SaveChangesAsync();
        }

        public async Task<puan?> GetpuanByIdAsync(int id)
        {
            return await puanlar.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdatepuanAsync(puan puan1)
        {
            _context.puanlar.Update(puan1);
            await _context.SaveChangesAsync();
        }
    }
}
