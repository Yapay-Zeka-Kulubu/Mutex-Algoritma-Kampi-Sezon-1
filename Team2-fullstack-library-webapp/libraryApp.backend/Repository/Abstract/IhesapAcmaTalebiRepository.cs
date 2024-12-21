using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IhesapAcmaTalebiRepository
    {
        IQueryable<hesapAcmaTalebi> hesapAcmaTalepleri { get; }
        Task<hesapAcmaTalebi> GethesapAcmaTalebiByIdAsync(int id);
        Task AddhesapAcmaTalebiAsync(hesapAcmaTalebi entity);
        Task UpdatehesapAcmaTalebiAsync(hesapAcmaTalebi entity);
        Task DeletehesapAcmaTalebiAsync(hesapAcmaTalebi hesapAcmaTalebi);
    }
}