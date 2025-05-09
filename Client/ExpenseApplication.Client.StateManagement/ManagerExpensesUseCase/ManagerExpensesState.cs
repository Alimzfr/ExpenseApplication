namespace ExpenseApplication.Client.StateManagement.ManagerExpensesUseCase;

public record ManagerExpensesState
{
    public bool Loading { get; init; }
    public bool Initialized { get; init; }
    public ExpenseRequestFilterDto ExpenseRequestFilter { get; init; }
    public List<ExpenseDto> ManagerExpenses { get; init; }
}