namespace ExpenseApplication.Client.StateManagement.ManagerExpensesUseCase;

public class ManagerExpensesStateFeature : Feature<ManagerExpensesState>
{
    public override string GetName() => nameof(ManagerExpensesState);

    protected override ManagerExpensesState GetInitialState()
    {
        return new ManagerExpensesState
        {
            Loading = false,
            Initialized = false,
            ExpenseRequestFilter = new ExpenseRequestFilterDto(),
            ManagerExpenses = []
        };
    }
}