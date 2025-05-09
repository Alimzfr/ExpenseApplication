namespace ExpenseApplication.Client.Services.Services;

public class DarkModeService(ICustomLocalStorageService localStorageService) : IDarkModeService
{
    public async Task<bool> GetDarkModeAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var isDarkMode = await localStorageService.GetItemAsync<bool?>(LocalStorageConstants.IsDarkMode, cancellationToken);
        if (isDarkMode is not null)
        {
            return isDarkMode.Value;
        }
        await SetDarkModeAsync(false, cancellationToken);
        return false;
    }

    public async Task SetDarkModeAsync(bool isDarkMode, CancellationToken cancellationToken = default(CancellationToken))
    {
        await localStorageService.SetItemAsync(LocalStorageConstants.IsDarkMode, isDarkMode, cancellationToken);
    }
}