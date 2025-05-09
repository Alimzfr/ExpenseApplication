namespace ExpenseApplication.Client.StateManagement.AccountantExpensesUseCase;

public record AccountantExpensesState
{
    public bool Loading { get; init; }
    public bool Initialized { get; init; }
    public ExpenseRequestFilterDto ExpenseRequestFilter { get; init; }
    public List<ExpenseDto> AccountantExpenses { get; init; }
}