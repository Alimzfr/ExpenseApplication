namespace ExpenseApplication.Client.StateManagement.ExpenseTransactionsUseCase;

public class ExpenseTransactionsReducers
{
    [ReducerMethod]
    public static ExpenseTransactionsState ReduceSetExpenseTransactionsLoadingAction(ExpenseTransactionsState state, ExpenseTransactionsActions.SetExpenseTransactionsLoadingAction action)
    {
        return state with
        {
            Loading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static ExpenseTransactionsState ReduceSetExpenseTransactionsInitializedAction(ExpenseTransactionsState state, ExpenseTransactionsActions.SetExpenseTransactionsInitializedAction action)
    {
        return state with
        {
            Initialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static ExpenseTransactionsState ReduceSetExpenseTransactionsAction(ExpenseTransactionsState state, ExpenseTransactionsActions.SetExpenseTransactionsAction action)
    {
        return state with
        {
            ExpenseTransactions = action.ExpenseTransactions
        };
    }

    [ReducerMethod]
    public static ExpenseTransactionsState ReduceSetExpenseTransactionsFilterAction(ExpenseTransactionsState state, ExpenseTransactionsActions.SetExpenseTransactionsFilterAction action)
    {
        return state with
        {
            ExpenseTransactionRequestFilter = action.ExpenseTransactionRequestFilter
        };
    }

    [ReducerMethod]
    public static ExpenseTransactionsState ReduceLoadExpenseTransactionsAction(ExpenseTransactionsState state, ExpenseTransactionsActions.LoadExpenseTransactionsAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static ExpenseTransactionsState ReduceClearEmployeeExpensesStateAction(ExpenseTransactionsState state, ExpenseTransactionsActions.ClearEmployeeExpensesStateAction action)
    {
        return state with
        {
            Loading = false,
            Initialized = false,
            ExpenseTransactionRequestFilter = new ExpenseTransactionRequestFilterDto(),
            ExpenseTransactions = []
        };
    }
}