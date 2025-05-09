namespace ExpenseApplication.Client.StateManagement.ManagerExpensesUseCase;

public class ManagerExpensesReducers
{
    [ReducerMethod]
    public static ManagerExpensesState ReduceSetManagerExpensesLoadingAction(ManagerExpensesState state, ManagerExpensesActions.SetManagerExpensesLoadingAction action)
    {
        return state with
        {
            Loading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static ManagerExpensesState ReduceSetManagerExpensesInitializedAction(ManagerExpensesState state, ManagerExpensesActions.SetManagerExpensesInitializedAction action)
    {
        return state with
        {
            Initialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static ManagerExpensesState ReduceSetManagerExpensesAction(ManagerExpensesState state, ManagerExpensesActions.SetManagerExpensesAction action)
    {
        return state with
        {
            ManagerExpenses = action.ManagerExpenses
        };
    }

    [ReducerMethod]
    public static ManagerExpensesState ReduceSetExpenseRequestFilterAction(ManagerExpensesState state, ManagerExpensesActions.SetExpenseRequestFilterAction action)
    {
        return state with
        {
            ExpenseRequestFilter = action.ExpenseRequestFilter
        };
    }

    [ReducerMethod]
    public static ManagerExpensesState ReduceLoadManagerExpensesAction(ManagerExpensesState state, ManagerExpensesActions.LoadManagerExpensesAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static ManagerExpensesState ReduceApproveExpenseAction(ManagerExpensesState state, ManagerExpensesActions.ApproveExpenseAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static ManagerExpensesState ReduceRejectExpenseAction(ManagerExpensesState state, ManagerExpensesActions.RejectExpenseAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static ManagerExpensesState ReduceClearManagerExpensesStateAction(ManagerExpensesState state, ManagerExpensesActions.ClearManagerExpensesStateAction action)
    {
        return state with
        {
            Loading = false,
            Initialized = false,
            ExpenseRequestFilter = new ExpenseRequestFilterDto(),
            ManagerExpenses = []
        };
    }
}