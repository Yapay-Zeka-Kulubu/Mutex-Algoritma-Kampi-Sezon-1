using AutoMapper;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfPunishRepository : IPunishRepository
    {
        private readonly LibraryDbContext _context;

        public EfPunishRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public IQueryable<Punishment> GetAllPunishmentsAsync => _context.Punishments;

        public async Task<Punishment> GetByIdAsync(int id)
        {
            return await _context.Punishments.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task CreatePunishAsync(Punishment punish)
        {
            if (punish == null)
                throw new ArgumentNullException(nameof(punish));

            _context.Punishments.Add(punish);
            await _context.SaveChangesAsync();
        }

        
      

        public async Task UpdatePunishAsync(Punishment punish)
        {

            if (punish == null)
                throw new ArgumentNullException(nameof(punish));

            _context.Punishments.Update(punish);
            await _context.SaveChangesAsync();

        }

        public async Task DeletePunishAsync(int id)
        {
            var punish = _context.Punishments.Find(id);
            if (punish != null)
            {
                _context.Punishments.Remove(punish);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentException("Punish doesn't found.");
            
        }
    }
}
