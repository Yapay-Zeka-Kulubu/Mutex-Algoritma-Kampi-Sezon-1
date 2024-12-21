using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface ImesajRepository
    {
        public IQueryable<mesaj> mesajlar { get; }
        Task<mesaj> GetmesajByIdAsync(int id);
        Task AddmesajAsync(mesaj entity);
        Task UpdatemesajAsync(mesaj entity);
        Task DeletemesajAsync(mesaj mesaj);
    }
}
