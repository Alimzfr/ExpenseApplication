namespace ExpenseApplication.Client.StateManagement.AccountantExpensesUseCase;

public class AccountantExpensesReducers
{
    [ReducerMethod]
    public static AccountantExpensesState ReduceSetAccountantExpensesLoadingAction(AccountantExpensesState state, AccountantExpensesActions.SetAccountantExpensesLoadingAction action)
    {
        return state with
        {
            Loading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static AccountantExpensesState ReduceSetAccountantExpensesInitializedAction(AccountantExpensesState state, AccountantExpensesActions.SetAccountantExpensesInitializedAction action)
    {
        return state with
        {
            Initialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static AccountantExpensesState ReduceSetAccountantExpensesAction(AccountantExpensesState state, AccountantExpensesActions.SetAccountantExpensesAction action)
    {
        return state with
        {
            AccountantExpenses = action.AccountantExpenses
        };
    }

    [ReducerMethod]
    public static AccountantExpensesState ReduceSetExpenseRequestFilterAction(AccountantExpensesState state, AccountantExpensesActions.SetExpenseRequestFilterAction action)
    {
        return state with
        {
            ExpenseRequestFilter = action.ExpenseRequestFilter
        };
    }

    [ReducerMethod]
    public static AccountantExpensesState ReduceLoadAccountantExpensesAction(AccountantExpensesState state, AccountantExpensesActions.LoadAccountantExpensesAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static AccountantExpensesState ReducePayExpenseAction(AccountantExpensesState state, AccountantExpensesActions.PayExpenseAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static AccountantExpensesState ReduceClearAccountantExpensesStateAction(AccountantExpensesState state, AccountantExpensesActions.ClearAccountantExpensesStateAction action)
    {
        return state with
        {
            Loading = false,
            Initialized = false,
            ExpenseRequestFilter = new ExpenseRequestFilterDto(),
            AccountantExpenses = []
        };
    }
}