using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Concrete
{
    public class EfSettingRepository : ISettingRepository
    {
        public IQueryable<Setting> Settings => _context.Settings;

        LibraryDbContext _context;

        public EfSettingRepository(LibraryDbContext libraryDbContext)
        {
            _context = libraryDbContext;
        }

        public async Task CreateSettingAsync(Setting settings)
        {
            _context.Settings.Add(settings);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSettingAsync(Setting settings)
        {
            _context.Settings.Remove(settings);
            await _context.SaveChangesAsync();
        }

        public async Task<Setting?> GetSettingByIdAsync(int id)
        {
            return await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Setting?> GetSettingByNameAsync(string name)
        {
            return await _context.Settings.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task UpdateSettingAsync(Setting settings)
        {
            _context.Settings.Update(settings);
            await _context.SaveChangesAsync();
        }
    }
}