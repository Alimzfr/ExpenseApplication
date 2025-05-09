namespace ExpenseApplication.Client.StateManagement.AccountantExpensesUseCase;

public abstract class AccountantExpensesActions
{
    public record SetAccountantExpensesLoadingAction(bool IsLoading);
    public record SetAccountantExpensesInitializedAction(bool IsInitialized);
    public record SetAccountantExpensesAction(List<ExpenseDto> AccountantExpenses);
    public record SetExpenseRequestFilterAction(ExpenseRequestFilterDto ExpenseRequestFilter);
    public record LoadAccountantExpensesAction(ExpenseRequestFilterDto ExpenseRequestFilter, CancellationToken CancellationToken);
    public record PayExpenseAction(PayExpenseFormDto PayExpenseForm, CancellationToken CancellationToken);
    public record ClearAccountantExpensesStateAction;
}