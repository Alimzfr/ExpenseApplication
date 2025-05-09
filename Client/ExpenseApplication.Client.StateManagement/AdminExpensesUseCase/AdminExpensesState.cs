namespace ExpenseApplication.Client.StateManagement.AdminExpensesUseCase;

public record AdminExpensesState
{
    public bool Loading { get; init; }
    public bool Initialized { get; init; }
    public ExpenseRequestFilterDto ExpenseRequestFilter { get; init; }
    public List<ExpenseDto> AdminExpenses { get; init; }
}