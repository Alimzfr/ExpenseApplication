namespace ExpenseApplication.Server.Infrastructure.Data;

/// <summary>
/// Represents the application's database context, which is used to interact with the SQL Server database.
/// Inherits from DbContext and implements IUnitOfWork.
/// </summary>
/// <param name="options">The options to be used by the DbContext.</param>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<UserToken> UserTokens => Set<UserToken>();
    public DbSet<ManagerEmployee> ManagerEmployees => Set<ManagerEmployee>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<ExpenseItem> ExpenseItems => Set<ExpenseItem>();
    public DbSet<ExpenseTransaction> ExpenseTransactions => Set<ExpenseTransaction>();

    /// <summary>
    /// This is a Serilog equivalent DbSet.
    /// </summary>
    public DbSet<Log> Logs => Set<Log>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Apply configurations from the current assembly
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Call the base class implementation
        base.OnModelCreating(builder);
    }
}