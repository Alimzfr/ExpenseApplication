namespace ExpenseApplication.Server.Infrastructure.Extensions;

/// <summary>
/// Provides extension methods for initializing and seeding the database.
/// </summary>
public static class DatabaseExtensions
{
    /// <summary>
    /// Initializes the database by applying any pending migrations and seeding initial data.
    /// </summary>
    /// <param name="webApplication">The web application instance.</param>
    public static async Task InitialiseDatabaseAsync(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var securityService = scope.ServiceProvider.GetRequiredService<ISecurityService>();

        // Apply any pending migrations
        context.Database.MigrateAsync().GetAwaiter().GetResult();

        // Seed initial data
        await SeedAsync(context, securityService);
    }


    /// <summary>
    /// Seeds initial data into the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="securityService">The security service for hashing passwords.</param>
    private static async Task SeedAsync(ApplicationDbContext context, ISecurityService securityService)
    {
        await SeedAccountsAsync(context, securityService);
    }

    /// <summary>
    /// Seeds initial user accounts and roles into the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="securityService">The security service for hashing passwords.</param>
    private static async Task SeedAccountsAsync(ApplicationDbContext context, ISecurityService securityService)
    {
        var adminRole = new Role { Name = CustomRoleConstants.Admin };
        var employeeRole = new Role { Name = CustomRoleConstants.Employee };
        var managerRole = new Role { Name = CustomRoleConstants.Manager };
        var accountantRole = new Role { Name = CustomRoleConstants.Accountant };
        if (!context.Roles.Any())
        {
            context.Add(adminRole);
            context.Add(employeeRole);
            context.Add(managerRole);
            context.Add(accountantRole);
            await context.SaveChangesAsync();
        }

        if (!context.Users.Any())
        {
            var adminUser = new User
            {
                Username = "Admin",
                DisplayName = "Admin User",
                IsActive = true,
                LastLoggedIn = null,
                Password = securityService.GetSha256Hash("123456"),
                SerialNumber = Guid.NewGuid().ToString("N")
            };
            var employeeAUser = new User
            {
                Username = "EmployeeA",
                DisplayName = "EmployeeA User",
                IsActive = true,
                LastLoggedIn = null,
                Password = securityService.GetSha256Hash("123456"),
                SerialNumber = Guid.NewGuid().ToString("N")
            };
            var employeeBUser = new User
            {
                Username = "EmployeeB",
                DisplayName = "EmployeeB User",
                IsActive = true,
                LastLoggedIn = null,
                Password = securityService.GetSha256Hash("123456"),
                SerialNumber = Guid.NewGuid().ToString("N")
            };
            var managerAUser = new User
            {
                Username = "ManagerA",
                DisplayName = "ManagerA User",
                IsActive = true,
                LastLoggedIn = null,
                Password = securityService.GetSha256Hash("123456"),
                SerialNumber = Guid.NewGuid().ToString("N")
            };
            var managerBUser = new User
            {
                Username = "ManagerB",
                DisplayName = "ManagerB User",
                IsActive = true,
                LastLoggedIn = null,
                Password = securityService.GetSha256Hash("123456"),
                SerialNumber = Guid.NewGuid().ToString("N")
            };
            var accountantUser = new User
            {
                Username = "Accountant",
                DisplayName = "Accountant User",
                IsActive = true,
                LastLoggedIn = null,
                Password = securityService.GetSha256Hash("123456"),
                SerialNumber = Guid.NewGuid().ToString("N")
            };
            context.Add(adminUser);
            context.Add(employeeAUser);
            context.Add(employeeBUser);
            context.Add(managerAUser);
            context.Add(managerBUser);
            context.Add(accountantUser);
            await context.SaveChangesAsync();

            context.Add(new UserRole { Role = adminRole, User = adminUser });
            context.Add(new UserRole { Role = employeeRole, User = employeeAUser });
            context.Add(new UserRole { Role = employeeRole, User = employeeBUser });
            context.Add(new UserRole { Role = managerRole, User = managerAUser });
            context.Add(new UserRole { Role = managerRole, User = managerBUser });
            context.Add(new UserRole { Role = accountantRole, User = accountantUser });
            context.Add(new ManagerEmployee { Manager = managerAUser, Employee = employeeAUser });
            context.Add(new ManagerEmployee { Manager = managerBUser, Employee = employeeBUser });
            await context.SaveChangesAsync();
        }
    }
}