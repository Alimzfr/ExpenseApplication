namespace ExpenseApplication.Client.StateManagement.AccountantExpensesUseCase;

public class AccountantExpensesStateFeature : Feature<AccountantExpensesState>
{
    public override string GetName() => nameof(AccountantExpensesState);

    protected override AccountantExpensesState GetInitialState()
    {
        return new AccountantExpensesState
        {
            Loading = false,
            Initialized = false,
            ExpenseRequestFilter = new ExpenseRequestFilterDto(),
            AccountantExpenses = []
        };
    }
}