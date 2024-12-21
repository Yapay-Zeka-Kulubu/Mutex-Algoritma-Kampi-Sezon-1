using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsersAsync { get; }
        Task<User> GetUseridAsync(int id);
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(User user);

    }
}
