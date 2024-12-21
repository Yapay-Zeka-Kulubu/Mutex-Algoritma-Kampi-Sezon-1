using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Concrete
{
    public class EfRoleRepository : IRoleRepository
    {
        public IQueryable<Role> Roles => _context.Roles;
        private LibraryDbContext _context;

        public EfRoleRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}