namespace ExpenseApplication.Server.Application.Account.Services;

public interface IRolesService
{
    Task<List<Role>> FindUserRolesAsync(int userId);
    Task<bool> IsUserInRoleAsync(int userId, string roleName);
    Task<List<User>> FindUsersInRoleAsync(string roleName);
}