using AutoMapper;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfRegisterRequestRepository : IRegisterRequestRepository
    {

        private readonly LibraryDbContext _context;

        public EfRegisterRequestRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public IQueryable<RegisterRequest> GetAllRegisterRequestsAsync => _context.RegisterRequests;

        public async Task<Role> GetAdminByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<RegisterRequest> GetByIdAsync(int id)
        {
            return await _context.RegisterRequests.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task UpdateAsync(RegisterRequest record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            _context.RegisterRequests.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task CreateRegisterRequestAsync(RegisterRequest record)
        {

            if (record == null)
                throw new ArgumentNullException(nameof(record));

            _context.RegisterRequests.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RegisterRequest record)
        {
            var efRegisterRequest = await _context.RegisterRequests.FindAsync(record);
            if (efRegisterRequest != null)
            {
                _context.RegisterRequests.Remove(efRegisterRequest);
                await _context.SaveChangesAsync();
            }
            else
                throw new ArgumentException("Record doesn't found");
            
        }

      
      
    }
}
