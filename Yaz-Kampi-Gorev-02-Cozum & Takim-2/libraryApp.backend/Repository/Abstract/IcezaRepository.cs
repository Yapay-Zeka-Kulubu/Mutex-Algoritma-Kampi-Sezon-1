using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IcezaRepository
    {
        public IQueryable<ceza> cezalar { get; }
        Task<ceza> GetcezaByIdAsync(int id);
        Task AddcezaAsync(ceza entity);
        Task UpdatecezaAsync(ceza entity);
        Task DeletecezaAsync(ceza ceza);
    }
}