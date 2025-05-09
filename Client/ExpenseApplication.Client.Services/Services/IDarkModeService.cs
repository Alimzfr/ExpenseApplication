namespace ExpenseApplication.Client.Services.Services;

public interface IDarkModeService
{
    Task<bool> GetDarkModeAsync(CancellationToken cancellationToken = default(CancellationToken));
    Task SetDarkModeAsync(bool isDarkMode, CancellationToken cancellationToken = default(CancellationToken));
}