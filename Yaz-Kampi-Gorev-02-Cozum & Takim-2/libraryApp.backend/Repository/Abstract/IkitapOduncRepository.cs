using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IkitapOduncRepository
    {
        public IQueryable<kitapOdunc> kitapOduncler { get; }
        Task<kitapOdunc> GetkitapOduncByIdAsync(int id);
        Task AddkitapOduncAsync(kitapOdunc entity);
        Task UpdatekitapOduncAsync(kitapOdunc entity);
        Task DeletekitapOduncAsync(kitapOdunc kitapOdunc);
    }
}