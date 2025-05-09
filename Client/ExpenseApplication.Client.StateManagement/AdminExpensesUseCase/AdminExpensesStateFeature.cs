namespace ExpenseApplication.Client.StateManagement.AdminExpensesUseCase;

public class AdminExpensesStateFeature : Feature<AdminExpensesState>
{
    public override string GetName() => nameof(AdminExpensesState);

    protected override AdminExpensesState GetInitialState()
    {
        return new AdminExpensesState
        {
            Loading = false,
            Initialized = false,
            ExpenseRequestFilter = new ExpenseRequestFilterDto(),
            AdminExpenses = []
        };
    }
}