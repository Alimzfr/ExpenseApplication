namespace ExpenseApplication.Server.Application.Account.Services;

public class RolesService(IUnitOfWork uow) : IRolesService
{
    private readonly DbSet<Role> roleDbSet = uow.Set<Role>();
    private readonly DbSet<User> userDbSet = uow.Set<User>();

    public async Task<List<Role>> FindUserRolesAsync(int userId)
    {
        var userRolesQuery = await roleDbSet
            .SelectMany(role => role.UserRoles, (role, userRole) => new { role, userRole })
            .Where(x => x.userRole.UserId == userId)
            .Select(x => x.role)
            .OrderBy(x => x.Name)
            .ToListAsync();

        return userRolesQuery;
    }

    public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
    {
        var userRole = await roleDbSet
            .Where(role => role.Name == roleName)
            .SelectMany(role => role.UserRoles, (role, userRole) => new { role, userRole })
            .Where(x => x.userRole.UserId == userId)
            .Select(x => x.role)
            .FirstOrDefaultAsync();

        return userRole is not null;
    }

    public async Task<List<User>> FindUsersInRoleAsync(string roleName)
    {
        var roleUserIdsQuery = roleDbSet
            .Where(role => role.Name == roleName)
            .SelectMany(role => role.UserRoles)
            .Select(userRole => userRole.UserId);

        return await userDbSet
            .Where(user => roleUserIdsQuery.Contains(user.Id))
            .ToListAsync();
    }
}