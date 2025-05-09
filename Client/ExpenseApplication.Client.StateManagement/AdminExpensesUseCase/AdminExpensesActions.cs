namespace ExpenseApplication.Client.StateManagement.AdminExpensesUseCase;

public abstract class AdminExpensesActions
{
    public record SetAdminExpensesLoadingAction(bool IsLoading);
    public record SetAdminExpensesInitializedAction(bool IsInitialized);
    public record SetAdminExpensesAction(List<ExpenseDto> AdminExpenses);
    public record SetExpenseRequestFilterAction(ExpenseRequestFilterDto ExpenseRequestFilter);
    public record LoadAdminExpensesAction(ExpenseRequestFilterDto ExpenseRequestFilter, CancellationToken CancellationToken);
    public record ClearAdminExpensesStateAction;
}