using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

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

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IQueryable<User> GetUsers()
        {
            return Users;
        }

        public User? GetUserById(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}