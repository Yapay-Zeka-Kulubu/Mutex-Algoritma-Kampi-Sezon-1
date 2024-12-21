using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IkitapYayinTalebiRepository
    {
        public IQueryable<kitapYayinTalebi> kitapYayinTalepleri { get; }
        Task<kitapYayinTalebi> GetkitapYayinTalebiByIdAsync(int id);
        Task AddkitapYayinTalebiAsync(kitapYayinTalebi entity);
        Task UpdatekitapYayinTalebiAsync(kitapYayinTalebi entity);
        Task DeletekitapYayinTalebiAsync(kitapYayinTalebi kitapYayinTalebi);
    }
}