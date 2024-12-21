using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IuserRepository
    {
        IQueryable<user> users { get; }
        Task<user> GetuserByIdAsync(int id);
        Task AdduserAsync(user entity);
        Task UpdateuserAsync(user entity);
        Task DeleteuserAsync(user user);
    }
}
