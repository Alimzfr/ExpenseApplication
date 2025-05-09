namespace ExpenseApplication.Client.StateManagement.AdminExpensesUseCase;

public class AdminExpensesReducers
{
    [ReducerMethod]
    public static AdminExpensesState ReduceSetAdminExpensesLoadingAction(AdminExpensesState state, AdminExpensesActions.SetAdminExpensesLoadingAction action)
    {
        return state with
        {
            Loading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static AdminExpensesState ReduceSetAdminExpensesInitializedAction(AdminExpensesState state, AdminExpensesActions.SetAdminExpensesInitializedAction action)
    {
        return state with
        {
            Initialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static AdminExpensesState ReduceSetAdminExpensesAction(AdminExpensesState state, AdminExpensesActions.SetAdminExpensesAction action)
    {
        return state with
        {
            AdminExpenses = action.AdminExpenses
        };
    }

    [ReducerMethod]
    public static AdminExpensesState ReduceSetExpenseRequestFilterAction(AdminExpensesState state, AdminExpensesActions.SetExpenseRequestFilterAction action)
    {
        return state with
        {
            ExpenseRequestFilter = action.ExpenseRequestFilter
        };
    }

    [ReducerMethod]
    public static AdminExpensesState ReduceLoadAdminExpensesAction(AdminExpensesState state, AdminExpensesActions.LoadAdminExpensesAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static AdminExpensesState ReduceClearAdminExpensesStateAction(AdminExpensesState state, AdminExpensesActions.ClearAdminExpensesStateAction action)
    {
        return state with
        {
            Loading = false,
            Initialized = false,
            ExpenseRequestFilter = new ExpenseRequestFilterDto(),
            AdminExpenses = []
        };
    }
}