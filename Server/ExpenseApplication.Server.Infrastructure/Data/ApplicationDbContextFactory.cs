namespace ExpenseApplication.Server.Infrastructure.Data;

/// <summary>
/// A factory for creating instances of <see cref="ApplicationDbContext"/> at design time.
/// Implements <see cref="IDesignTimeDbContextFactory{ApplicationDbContext}"/> to enable design-time services such as Migrations.
/// </summary>
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    /// <summary>
    /// Creates a new instance of <see cref="ApplicationDbContext"/> using the specified arguments.
    /// </summary>
    /// <param name="args">Arguments provided by the design-time service.</param>
    /// <returns>An instance of <see cref="ApplicationDbContext"/>.</returns>
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Get the current directory path
        var basePath = Directory.GetCurrentDirectory();

        // Build the configuration from the appsettings.json file
        var configuration = new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile("appsettings.json").Build();

        // Create a DbContextOptionsBuilder and configure it to use SQL Server
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);

        // Return a new instance of ApplicationDbContext with the configured options
        return new ApplicationDbContext(builder.Options);
    }
}