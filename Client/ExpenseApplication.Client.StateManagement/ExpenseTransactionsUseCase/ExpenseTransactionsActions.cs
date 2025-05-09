namespace ExpenseApplication.Client.StateManagement.ExpenseTransactionsUseCase;

public abstract class ExpenseTransactionsActions
{
    public record SetExpenseTransactionsLoadingAction(bool IsLoading);
    public record SetExpenseTransactionsInitializedAction(bool IsInitialized);
    public record SetExpenseTransactionsAction(List<ExpenseTransactionDto> ExpenseTransactions);
    public record SetExpenseTransactionsFilterAction(ExpenseTransactionRequestFilterDto ExpenseTransactionRequestFilter);
    public record LoadExpenseTransactionsAction(ExpenseTransactionRequestFilterDto ExpenseTransactionRequestFilter, CancellationToken CancellationToken);
    public record ClearEmployeeExpensesStateAction;
}