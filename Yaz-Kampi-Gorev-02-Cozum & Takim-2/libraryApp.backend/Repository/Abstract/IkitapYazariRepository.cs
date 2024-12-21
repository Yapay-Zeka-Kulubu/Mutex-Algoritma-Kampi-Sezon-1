using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IkitapYazariRepository
    {
        public IQueryable<kitapYazari> kitapYazarlari { get; }
        Task<kitapYazari> GetkitapYazariByIdAsync(int id);
        Task AddkitapYazariAsync(kitapYazari entity);
        Task UpdatekitapYazariAsync(kitapYazari entity);
        Task DeletekitapYazariAsync(kitapYazari kitapYazari);
    }
}