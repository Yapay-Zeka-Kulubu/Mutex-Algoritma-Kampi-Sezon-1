using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IpuanRepository
    {
        public IQueryable<puan> puanlar { get; }
        Task<puan> GetpuanByIdAsync(int id);
        Task AddpuanAsync(puan entity);
        Task UpdatepuanAsync(puan entity);
        Task DeletepuanAsync(puan puan);
    }
}
