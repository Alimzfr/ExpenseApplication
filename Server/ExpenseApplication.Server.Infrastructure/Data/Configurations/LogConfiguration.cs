namespace ExpenseApplication.Server.Infrastructure.Data.Configurations;

/// <summary>
/// Log entity fluent api database configuration.
/// This entity is used by Serilog and the configuration should be as same as Serilog expectation.
/// </summary>
public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.HasIndex(log => log.TimeStamp);
    }
}