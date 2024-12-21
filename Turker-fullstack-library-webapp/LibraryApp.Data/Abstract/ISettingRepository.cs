using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract;

public interface ISettingRepository
{
    IQueryable<Setting> Settings { get; }

    Task<Setting?> GetSettingByIdAsync(int id);
    Task<Setting?> GetSettingByNameAsync(string name);
    Task CreateSettingAsync(Setting settings);
    Task UpdateSettingAsync(Setting settings);
    Task DeleteSettingAsync(Setting settings);
}