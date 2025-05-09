namespace ExpenseApplication.Server.Infrastructure.Data.Configurations;

/// <summary>
/// Expense entity fluent api database configuration
/// </summary>
public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(expense => expense.Id);
        builder.Property(expense => expense.Id).HasColumnOrder(0);
        builder.HasOne(expense => expense.User).WithMany(user => user.Expenses).HasForeignKey(expense => expense.UserId);
        builder.Property(expense => expense.TraceId).IsRequired();
        builder.HasIndex(expense => expense.TraceId).IsUnique();
        builder.Property(expense => expense.Title).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(expense => expense.Description).HasColumnType("varchar").HasMaxLength(450);
        builder.Property(expense => expense.CurrencyType).IsRequired();
        builder.Property(expense => expense.ExpenseStatus).IsRequired();
        builder.Property(expense => expense.CreatedDate).HasColumnType("datetime2(0)").IsRequired();
        builder.HasIndex(expense => expense.CreatedDate);
        builder.Property(expense => expense.CreateBy).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(expense => expense.ModifyDate).HasColumnType("datetime2(0)").IsRequired().IsConcurrencyToken();
        builder.HasIndex(expense => expense.ModifyDate);
        builder.Property(expense => expense.ModifiedBy).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(expense => expense.IsDeleted).HasDefaultValue(false).IsRequired();
    }
}