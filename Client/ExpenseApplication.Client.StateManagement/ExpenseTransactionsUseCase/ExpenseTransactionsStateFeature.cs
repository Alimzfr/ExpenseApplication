namespace ExpenseApplication.Client.StateManagement.ExpenseTransactionsUseCase;

public class ExpenseTransactionsStateFeature : Feature<ExpenseTransactionsState>
{
    public override string GetName() => nameof(ExpenseTransactionsState);

    protected override ExpenseTransactionsState GetInitialState()
    {
        return new ExpenseTransactionsState
        {
            Loading = false,
            Initialized = false,
            ExpenseTransactionRequestFilter = new ExpenseTransactionRequestFilterDto(),
            ExpenseTransactions = []
        };
    }
}