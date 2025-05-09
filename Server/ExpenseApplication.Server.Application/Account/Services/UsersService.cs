namespace ExpenseApplication.Server.Application.Account.Services;

public class UsersService(IUnitOfWork unitOfWork, ISecurityService securityService, IHttpContextAccessor contextAccessor) : IUsersService
{
    private readonly DbSet<User> userDbSet = unitOfWork.Set<User>();

    public async Task<User?> FindUserAsync(int userId)
    {
        var user = await userDbSet.FindAsync(userId);
        return user;
    }

    public async Task<User?> FindUserAsync(string username, string password)
    {
        var passwordHash = securityService.GetSha256Hash(password);
        return await userDbSet.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
    }

    public async Task<string?> GetSerialNumberAsync(int userId)
    {
        var user = await FindUserAsync(userId);
        return user?.SerialNumber;
    }

    public async Task UpdateUserLastActivityDateAsync(int userId)
    {
        var user = await FindUserAsync(userId);
        if (user is null)
        {
            return;
        }
        if (user.LastLoggedIn is not null)
        {
            var updateLastActivityDate = TimeSpan.FromMinutes(value: 2);
            var currentUtc = DateTime.UtcNow;
            var timeElapsed = currentUtc.Subtract(user.LastLoggedIn.Value);

            if (timeElapsed < updateLastActivityDate)
            {
                return;
            }
        }

        user.LastLoggedIn = DateTime.UtcNow;
        await unitOfWork.SaveChangesAsync();
    }

    public int GetCurrentUserId()
    {
        var claimsIdentity = contextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
        var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
        var userId = userDataClaim?.Value;

        return string.IsNullOrWhiteSpace(userId)
            ? 0
            : int.Parse(userId, NumberStyles.Number, CultureInfo.InvariantCulture);
    }

    public async Task<User?> GetCurrentUserAsync()
    {
        var userId = GetCurrentUserId();
        var user = await FindUserAsync(userId);
        return user;
    }

    public async Task<(bool Succeeded, string Error)> ChangePasswordAsync(User user, string currentPassword, string newPassword)
    {
        ArgumentNullException.ThrowIfNull(user);

        var currentPasswordHash = securityService.GetSha256Hash(currentPassword);
        if (!string.Equals(user.Password, currentPasswordHash, StringComparison.Ordinal))
        {
            return (false, "Current password is wrong.");
        }

        user.Password = securityService.GetSha256Hash(newPassword);
        await unitOfWork.SaveChangesAsync();

        return (true, string.Empty);
    }
}