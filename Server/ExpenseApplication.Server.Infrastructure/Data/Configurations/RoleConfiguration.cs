namespace ExpenseApplication.Server.Infrastructure.Data.Configurations;

/// <summary>
/// Role entity fluent api database configuration
/// </summary>
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(role => role.Id);
        builder.Property(role => role.Id).HasColumnOrder(0);
        builder.Property(role => role.Name).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.HasIndex(role => role.Name).IsUnique();
    }
}