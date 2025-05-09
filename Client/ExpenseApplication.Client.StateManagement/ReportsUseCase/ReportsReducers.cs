namespace ExpenseApplication.Client.StateManagement.ReportsUseCase;

public class ReportsReducers
{
    [ReducerMethod]
    public static ReportsState ReduceSetExpenseStatusTypeCountsLoadingAction(ReportsState state, ReportsActions.SetExpenseStatusTypeCountsLoadingAction action)
    {
        return state with
        {
            ExpenseStatusTypeCountsLoading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetExpenseStatusTypeCountsInitializedAction(ReportsState state, ReportsActions.SetExpenseStatusTypeCountsInitializedAction action)
    {
        return state with
        {
            ExpenseStatusTypeCountsInitialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetExpenseStatusTypeCountsAction(ReportsState state, ReportsActions.SetExpenseStatusTypeCountsAction action)
    {
        return state with
        {
            ExpenseStatusTypeCounts = action.ExpenseStatusTypeCounts
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceLoadExpenseStatusTypeCountsAction(ReportsState state, ReportsActions.LoadExpenseStatusTypeCountsAction action)
    {
        return state;
    }



    [ReducerMethod]
    public static ReportsState ReduceSetSystemLogLevelCountsLoadingAction(ReportsState state, ReportsActions.SetSystemLogLevelCountsLoadingAction action)
    {
        return state with
        {
            SystemLogLevelCountsLoading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetSystemLogLevelCountsInitializedAction(ReportsState state, ReportsActions.SetSystemLogLevelCountsInitializedAction action)
    {
        return state with
        {
            SystemLogLevelCountsInitialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetSystemLogLevelCountsAction(ReportsState state, ReportsActions.SetSystemLogLevelCountsAction action)
    {
        return state with
        {
            SystemLogLevelCounts = action.SystemLogLevelCounts
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceLoadSystemLogLevelCountsAction(ReportsState state, ReportsActions.LoadSystemLogLevelCountsAction action)
    {
        return state;
    }

    

    [ReducerMethod]
    public static ReportsState ReduceSetTotalPaidExpensesMonthlyAmountsLoadingAction(ReportsState state, ReportsActions.SetTotalPaidExpensesMonthlyAmountsLoadingAction action)
    {
        return state with
        {
            TotalPaidExpensesMonthlyAmountsLoading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetTotalPaidExpensesMonthlyAmountsInitializedAction(ReportsState state, ReportsActions.SetTotalPaidExpensesMonthlyAmountsInitializedAction action)
    {
        return state with
        {
            TotalPaidExpensesMonthlyAmountsInitialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetTotalPaidExpensesMonthlyAmountsAction(ReportsState state, ReportsActions.SetTotalPaidExpensesMonthlyAmountsAction action)
    {
        return state with
        {
            TotalPaidExpensesMonthlyAmounts = action.TotalPaidExpensesMonthlyAmounts
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceLoadTotalPaidExpensesMonthlyAmountsAction(ReportsState state, ReportsActions.LoadTotalPaidExpensesMonthlyAmountsAction action)
    {
        return state with
        {
            TotalPaidExpensesMonthlyAmountsReportYear = action.Year
        };
    }

    

    [ReducerMethod]
    public static ReportsState ReduceSetExpenseStatusTypeMonthlyCountsLoadingAction(ReportsState state, ReportsActions.SetExpenseStatusTypeMonthlyCountsLoadingAction action)
    {
        return state with
        {
            ExpenseStatusTypeMonthlyCountsLoading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetExpenseStatusTypeMonthlyCountsInitializedAction(ReportsState state, ReportsActions.SetExpenseStatusTypeMonthlyCountsInitializedAction action)
    {
        return state with
        {
            ExpenseStatusTypeMonthlyCountsInitialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetExpenseStatusTypeMonthlyCountsAction(ReportsState state, ReportsActions.SetExpenseStatusTypeMonthlyCountsAction action)
    {
        return state with
        {
            ExpenseStatusTypeMonthlyCounts = action.ExpenseStatusTypeMonthlyCounts
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceLoadExpenseStatusTypeMonthlyCountsAction(ReportsState state, ReportsActions.LoadExpenseStatusTypeMonthlyCountsAction action)
    {
        return state with
        {
            ExpenseStatusTypeMonthlyCountsReportYear = action.Year
        };
    }


    
    [ReducerMethod]
    public static ReportsState ReduceSetExpenseActionTypeMonthlyCountsLoadingAction(ReportsState state, ReportsActions.SetExpenseActionTypeMonthlyCountsLoadingAction action)
    {
        return state with
        {
            ExpenseActionTypeMonthlyCountsLoading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetExpenseActionTypeMonthlyCountsInitializedAction(ReportsState state, ReportsActions.SetExpenseActionTypeMonthlyCountsInitializedAction action)
    {
        return state with
        {
            ExpenseActionTypeMonthlyCountsInitialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceSetExpenseActionTypeMonthlyCountsAction(ReportsState state, ReportsActions.SetExpenseActionTypeMonthlyCountsAction action)
    {
        return state with
        {
            ExpenseActionTypeMonthlyCounts = action.ExpenseActionTypeMonthlyCounts
        };
    }

    [ReducerMethod]
    public static ReportsState ReduceLoadExpenseActionTypeMonthlyCountsAction(ReportsState state, ReportsActions.LoadExpenseActionTypeMonthlyCountsAction action)
    {
        return state with
        {
            ExpenseActionTypeMonthlyCountsReportYear = action.Year
        };
    }

    
    
    [ReducerMethod]
    public static ReportsState ReduceClearReportsStateAction(ReportsState state, ReportsActions.ClearReportsStateAction action)
    {
        return state with
        {
            ExpenseStatusTypeCountsLoading = false,
            ExpenseStatusTypeCountsInitialized = false,
            ExpenseStatusTypeCounts = [],

            SystemLogLevelCountsLoading = false,
            SystemLogLevelCountsInitialized = false,
            SystemLogLevelCounts = [],

            TotalPaidExpensesMonthlyAmountsLoading = false,
            TotalPaidExpensesMonthlyAmountsInitialized = false,
            TotalPaidExpensesMonthlyAmounts = [],
            TotalPaidExpensesMonthlyAmountsReportYear = DateTime.Now.Year,

            ExpenseStatusTypeMonthlyCountsLoading = false,
            ExpenseStatusTypeMonthlyCountsInitialized = false,
            ExpenseStatusTypeMonthlyCounts = [],
            ExpenseStatusTypeMonthlyCountsReportYear = DateTime.Now.Year,

            ExpenseActionTypeMonthlyCountsLoading = false,
            ExpenseActionTypeMonthlyCountsInitialized = false,
            ExpenseActionTypeMonthlyCounts = [],
            ExpenseActionTypeMonthlyCountsReportYear = DateTime.Now.Year
        };
    }
}