namespace ExpenseApplication.Server.Infrastructure.Data.Configurations;

/// <summary>
/// User entity fluent api database configuration
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id).HasColumnOrder(0);
        builder.Property(user => user.DisplayName).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(user => user.Username).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.HasIndex(user => user.Username).IsUnique();
        builder.Property(user => user.Password).HasColumnType("varchar").HasMaxLength(450).IsRequired();
        builder.Property(user => user.LastLoggedIn).HasColumnType("datetime2(0)").HasMaxLength(36);
        builder.Property(user => user.SerialNumber).HasColumnType("varchar").HasMaxLength(36);
    }
}