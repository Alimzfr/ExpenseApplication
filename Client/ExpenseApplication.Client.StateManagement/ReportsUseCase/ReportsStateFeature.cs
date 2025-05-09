namespace ExpenseApplication.Client.StateManagement.ReportsUseCase;

public class ReportsStateFeature : Feature<ReportsState>
{
    public override string GetName() => nameof(ReportsState);

    protected override ReportsState GetInitialState()
    {
        return new ReportsState
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