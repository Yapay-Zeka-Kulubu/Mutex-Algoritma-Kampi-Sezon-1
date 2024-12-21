using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IsayfaRepository
    {
        public IQueryable<sayfa> sayfalar { get; }
        Task<sayfa> GetsayfaByIdAsync(int id);
        Task AddsayfaAsync(sayfa entity);
        Task UpdatesayfaAsync(sayfa entity);
        Task DeletesayfaAsync(sayfa sayfa);
    }
}