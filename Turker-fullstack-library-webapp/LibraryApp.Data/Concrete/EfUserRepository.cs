using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        public IQueryable<User> Users => _context.Users;
        private LibraryDbContext _context;

        public EfUserRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task ResetMonthlyScores()
        {
            await _context.Users.ForEachAsync(u =>
            {
                u.MonthlyScore = 0;
                u.IsStaffOfPreviousMonth = false;
                u.ScoreLastResetDate = DateTime.UtcNow;
            });
            await _context.SaveChangesAsync();
        }
    }
}