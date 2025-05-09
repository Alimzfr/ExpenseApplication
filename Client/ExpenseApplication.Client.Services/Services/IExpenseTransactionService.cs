namespace ExpenseApplication.Client.Services.Services;

public interface IExpenseTransactionService
{
    Task<BaseResponseDto<List<ExpenseTransactionDto>>> GetExpenseTransactions(ExpenseTransactionRequestFilterDto expenseTransactionRequestFilter, CancellationToken cancellationToken = default(CancellationToken));
}