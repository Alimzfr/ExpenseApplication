namespace ExpenseApplication.Server.Infrastructure.Data.Configurations;

/// <summary>
/// UserRole entity fluent api database configuration
/// </summary>
public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(userRole => new { UserId = userRole.UserId, RoleId = userRole.RoleId });
        builder.HasOne(userRole => userRole.Role).WithMany(user => user.UserRoles).HasForeignKey(userRole => userRole.RoleId);
        builder.HasOne(userRole => userRole.User).WithMany(user => user.UserRoles).HasForeignKey(userRole => userRole.UserId);
    }
}