namespace ExpenseApplication.Server.Infrastructure.Data.Configurations;

/// <summary>
/// ExpenseItem entity fluent api database configuration
/// </summary>
public class ExpenseItemConfiguration : IEntityTypeConfiguration<ExpenseItem>
{
    public void Configure(EntityTypeBuilder<ExpenseItem> builder)
    {
        builder.HasKey(expenseItem => expenseItem.Id);
        builder.Property(expenseItem => expenseItem.Id).HasColumnOrder(0);
        builder.HasOne(expenseItem => expenseItem.Expense).WithMany(expenseMaster => expenseMaster.ExpenseItems).HasForeignKey(expenseDetail => expenseDetail.ExpenseId);
        builder.Property(expenseItem => expenseItem.Purpose).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(expenseItem => expenseItem.Amount).IsRequired();
    }
}