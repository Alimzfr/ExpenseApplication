namespace ExpenseApplication.Client.StateManagement.EmployeeExpensesUseCase;

public class EmployeeExpensesReducers
{
    [ReducerMethod]
    public static EmployeeExpensesState ReduceSetEmployeeExpensesLoadingAction(EmployeeExpensesState state, EmployeeExpensesActions.SetEmployeeExpensesLoadingAction action)
    {
        return state with
        {
            Loading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static EmployeeExpensesState ReduceSetEmployeeExpensesInitializedAction(EmployeeExpensesState state, EmployeeExpensesActions.SetEmployeeExpensesInitializedAction action)
    {
        return state with
        {
            Initialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static EmployeeExpensesState ReduceSetEmployeeExpensesAction(EmployeeExpensesState state, EmployeeExpensesActions.SetEmployeeExpensesAction action)
    {
        return state with
        {
            EmployeeExpenses = action.EmployeeExpenses
        };
    }

    [ReducerMethod]
    public static EmployeeExpensesState ReduceSetExpenseRequestFilterAction(EmployeeExpensesState state, EmployeeExpensesActions.SetExpenseRequestFilterAction action)
    {
        return state with
        {
            ExpenseRequestFilter = action.ExpenseRequestFilter
        };
    }

    [ReducerMethod]
    public static EmployeeExpensesState ReduceSetEmployeeEditingExpenseAction(EmployeeExpensesState state, EmployeeExpensesActions.SetEmployeeEditingExpenseAction action)
    {
        return state with
        {
            EmployeeEditingExpense = action.ExpenseForm
        };
    }

    [ReducerMethod]
    public static EmployeeExpensesState ReduceLoadEmployeeExpensesAction(EmployeeExpensesState state, EmployeeExpensesActions.LoadEmployeeExpensesAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static EmployeeExpensesState ReduceSubmitCreateExpenseAction(EmployeeExpensesState state, EmployeeExpensesActions.SubmitCreateExpenseAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static EmployeeExpensesState ReduceSubmitEditExpenseAction(EmployeeExpensesState state, EmployeeExpensesActions.SubmitEditExpenseAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static EmployeeExpensesState ReduceClearEmployeeExpensesStateAction(EmployeeExpensesState state, EmployeeExpensesActions.ClearEmployeeExpensesStateAction action)
    {
        return state with
        {
            Loading = false,
            Initialized = false,
            ExpenseRequestFilter = new ExpenseRequestFilterDto(),
            EmployeeExpenses = [],
            EmployeeEditingExpense = new ExpenseFormDto()
        };
    }
}