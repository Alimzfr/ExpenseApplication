namespace ExpenseApplication.Client.StateManagement.ManagerExpensesUseCase;

public abstract class ManagerExpensesActions
{
    public record SetManagerExpensesLoadingAction(bool IsLoading);
    public record SetManagerExpensesInitializedAction(bool IsInitialized);
    public record SetManagerExpensesAction(List<ExpenseDto> ManagerExpenses);
    public record SetExpenseRequestFilterAction(ExpenseRequestFilterDto ExpenseRequestFilter);
    public record LoadManagerExpensesAction(ExpenseRequestFilterDto ExpenseRequestFilter, CancellationToken CancellationToken);
    public record ApproveExpenseAction(ApproveExpenseFormDto ApproveExpenseForm, CancellationToken CancellationToken);
    public record RejectExpenseAction(RejectExpenseFormDto RejectExpenseForm, CancellationToken CancellationToken);
    public record ClearManagerExpensesStateAction;
}