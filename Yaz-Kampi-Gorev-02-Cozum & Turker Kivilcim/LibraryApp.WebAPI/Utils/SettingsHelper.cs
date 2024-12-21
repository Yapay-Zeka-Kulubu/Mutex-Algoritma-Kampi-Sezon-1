using LibraryApp.Data.Abstract;

namespace LibraryApp.WebAPI.Utils;

public static class SettingsHelper
{
    public static int AllowedDelayForResponses { get; private set; }
    public static float FinePerDay { get; private set; }
    public static int DefaultBorrowDuration { get; private set; }
    public static int ExtraDurationForReturningFast { get; private set; }

    public static async Task InitSettingsFromDb(ISettingRepository settingRepository)
    {
        AllowedDelayForResponses = (int)((await settingRepository.GetSettingByNameAsync("allowed-delay-for-responses"))?.Value ?? 1);
        FinePerDay = (await settingRepository.GetSettingByNameAsync("fine-per-day"))?.Value ?? 1;
        DefaultBorrowDuration = (int)((await settingRepository.GetSettingByNameAsync("default-borrow-duration"))?.Value ?? 1);
        ExtraDurationForReturningFast = (int)((await settingRepository.GetSettingByNameAsync("extra-duration-for-returning-fast"))?.Value ?? 1);
    }
}