namespace ExpenseApplication.Server.Infrastructure.Data.Configurations;

/// <summary>
/// ExpenseTransaction entity fluent api database configuration
/// </summary>
public class ExpenseTransactionConfiguration : IEntityTypeConfiguration<ExpenseTransaction>
{
    public void Configure(EntityTypeBuilder<ExpenseTransaction> builder)
    {
        builder.HasKey(expenseTransaction => expenseTransaction.Id);
        builder.Property(expenseTransaction => expenseTransaction.Id).HasColumnOrder(0);
        builder.HasOne(expenseTransaction => expenseTransaction.User).WithMany(user => user.ExpenseTransactions).HasForeignKey(expenseTransaction => expenseTransaction.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(expenseTransaction => expenseTransaction.Expense).WithMany(expense => expense.ExpenseTransactions).HasForeignKey(expenseTransaction => expenseTransaction.ExpenseId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(expenseTransaction => expenseTransaction.ActionDateTime).HasColumnType("datetime2(0)").IsRequired();
        builder.Property(expenseTransaction => expenseTransaction.Comments).HasColumnType("varchar").HasMaxLength(450);
    }
}