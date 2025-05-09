namespace ExpenseApplication.Server.Infrastructure.Data.Configurations;

/// <summary>
/// ManagerEmployee entity fluent api database configuration
/// </summary>
public class ManagerEmployeeConfiguration : IEntityTypeConfiguration<ManagerEmployee>
{
    public void Configure(EntityTypeBuilder<ManagerEmployee> builder)
    {
        builder.HasKey(managerEmployee => new { ManagerId = managerEmployee.ManagerId, EmployeeId = managerEmployee.EmployeeId });
        builder.HasOne(managerEmployee => managerEmployee.Manager).WithMany(user => user.ManagerEmployees).HasForeignKey(managerEmployee => managerEmployee.ManagerId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(managerEmployee => managerEmployee.Employee).WithMany(user => user.EmployeeManagers).HasForeignKey(managerEmployee => managerEmployee.EmployeeId).OnDelete(DeleteBehavior.Restrict);
    }
}