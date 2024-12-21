using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IkitapRepository
    {
        public IQueryable<kitap> kitaplar { get; }
        Task<kitap> GetkitapByIdAsync(int id);
        Task AddkitapAsync(kitap entity);
        Task UpdatekitapAsync(kitap entity);
        Task DeletekitapAsync(kitap kitap);
    }
}