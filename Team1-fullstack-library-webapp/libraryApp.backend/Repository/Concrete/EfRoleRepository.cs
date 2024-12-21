
using AutoMapper;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfRoleRepository : IRoleRepository
    {
        private readonly LibraryDbContext _context;

        public EfRoleRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public IQueryable<Role> GetAllRolesAsync => _context.Roles;

        public async Task CreateRoleAsync(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteRoleAsync(int id)
        {
            var efRole = await _context.Roles.FindAsync(id);
            if (efRole != null)
            {
                _context.Roles.Remove(efRole);
                await _context.SaveChangesAsync();
            }
            else
                throw new ArgumentException("Role doesn't found");
            
        }

        public async Task<Role> GetRoleIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
