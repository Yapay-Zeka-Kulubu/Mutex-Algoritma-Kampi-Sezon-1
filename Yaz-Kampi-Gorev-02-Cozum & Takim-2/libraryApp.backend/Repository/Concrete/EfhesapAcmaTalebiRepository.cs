using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfhesapAcmaTalebiRepository : IhesapAcmaTalebiRepository
    {
        public IQueryable<hesapAcmaTalebi> hesapAcmaTalepleri => _context.hesapAcmaTalepleri;
        private libraryDBContext _context;
        public EfhesapAcmaTalebiRepository(libraryDBContext context)
        {
            _context = context;
        }
        public async Task AddhesapAcmaTalebiAsync(hesapAcmaTalebi hesapAcmaTalebi1)
        {
            _context.hesapAcmaTalepleri.Add(hesapAcmaTalebi1);
            await _context.SaveChangesAsync();
        }

        public async Task DeletehesapAcmaTalebiAsync(hesapAcmaTalebi hesapAcmaTalebi1)
        {
            _context.hesapAcmaTalepleri.Remove(hesapAcmaTalebi1);
            await _context.SaveChangesAsync();
        }

        public async Task<hesapAcmaTalebi?> GethesapAcmaTalebiByIdAsync(int id)
        {
            return await hesapAcmaTalepleri.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdatehesapAcmaTalebiAsync(hesapAcmaTalebi hesapAcmaTalebi1)
        {
            _context.hesapAcmaTalepleri.Update(hesapAcmaTalebi1);
            await _context.SaveChangesAsync();
        }
    }
}