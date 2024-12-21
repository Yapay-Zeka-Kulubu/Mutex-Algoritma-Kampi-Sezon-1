using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAllRolesAsync { get; }
        Task<Role> GetRoleIdAsync(int id);
        Task CreateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        Task UpdateRoleAsync(Role role);




    }
}
