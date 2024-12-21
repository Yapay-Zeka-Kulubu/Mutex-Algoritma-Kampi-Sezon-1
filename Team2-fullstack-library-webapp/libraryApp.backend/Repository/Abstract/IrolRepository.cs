using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IrolRepository
    {
        public IQueryable<rol> roller { get; }
        Task<rol> GetrolByIdAsync(int id);
        Task AddrolAsync(rol entity);
        Task UpdaterolAsync(rol entity);
        Task DeleterolAsync(rol rol);
    }
}