namespace ExpenseApplication.Client.StateManagement.EmployeeExpensesUseCase;

public record EmployeeExpensesState
{
    public bool Loading { get; init; }
    public bool Initialized { get; init; }
    public ExpenseRequestFilterDto ExpenseRequestFilter { get; init; }
    public List<ExpenseDto> EmployeeExpenses { get; init; }
    public ExpenseFormDto EmployeeEditingExpense { get; init; }
}