namespace ExpenseApplication.Client.StateManagement.EmployeeExpensesUseCase;

public abstract class EmployeeExpensesActions
{
    public record SetEmployeeExpensesLoadingAction(bool IsLoading);
    public record SetEmployeeExpensesInitializedAction(bool IsInitialized);
    public record SetEmployeeExpensesAction(List<ExpenseDto> EmployeeExpenses);
    public record SetExpenseRequestFilterAction(ExpenseRequestFilterDto ExpenseRequestFilter);
    public record SetEmployeeEditingExpenseAction(ExpenseFormDto ExpenseForm);
    public record LoadEmployeeExpensesAction(ExpenseRequestFilterDto ExpenseRequestFilter, CancellationToken CancellationToken);
    public record LoadEmployeeEditingExpenseAction(int ExpenseId, CancellationToken CancellationToken);
    public record SubmitCreateExpenseAction(ExpenseFormDto ExpenseForm, CancellationToken CancellationToken);
    public record SubmitEditExpenseAction(ExpenseFormDto ExpenseForm, CancellationToken CancellationToken);
    public record ClearEmployeeExpensesStateAction;
}