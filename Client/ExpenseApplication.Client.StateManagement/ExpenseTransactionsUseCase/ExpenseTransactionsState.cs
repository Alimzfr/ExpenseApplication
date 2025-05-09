namespace ExpenseApplication.Client.StateManagement.ExpenseTransactionsUseCase;

public record ExpenseTransactionsState
{
    public bool Loading { get; init; }
    public bool Initialized { get; init; }
    public ExpenseTransactionRequestFilterDto ExpenseTransactionRequestFilter { get; init; }
    public List<ExpenseTransactionDto> ExpenseTransactions { get; init; }
}