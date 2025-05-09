namespace ExpenseApplication.Server.Application.Account.Services;

public interface IUsersService
{
    Task<string?> GetSerialNumberAsync(int userId);
    Task<User?> FindUserAsync(string username, string password);
    Task<User?> FindUserAsync(int userId);
    Task UpdateUserLastActivityDateAsync(int userId);
    Task<User?> GetCurrentUserAsync();
    int GetCurrentUserId();
    Task<(bool Succeeded, string Error)> ChangePasswordAsync(User user, string currentPassword, string newPassword);
}