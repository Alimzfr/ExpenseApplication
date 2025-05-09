namespace ExpenseApplication.Client.StateManagement.ReportsUseCase;

public record ReportsState
{
    public bool ExpenseStatusTypeCountsLoading { get; init; }
    public bool ExpenseStatusTypeCountsInitialized { get; init; }
    public List<ExpenseStatusTypeCountDto> ExpenseStatusTypeCounts { get; init; }

    public bool SystemLogLevelCountsLoading { get; init; }
    public bool SystemLogLevelCountsInitialized { get; init; }
    public List<SystemLogLevelCountDto> SystemLogLevelCounts { get; init; }

    public bool TotalPaidExpensesMonthlyAmountsLoading { get; init; }
    public bool TotalPaidExpensesMonthlyAmountsInitialized { get; init; }
    public List<TotalPaidExpensesMonthlyAmountDto> TotalPaidExpensesMonthlyAmounts { get; init; }
    public int TotalPaidExpensesMonthlyAmountsReportYear { get; init; }

    public bool ExpenseStatusTypeMonthlyCountsLoading { get; init; }
    public bool ExpenseStatusTypeMonthlyCountsInitialized { get; init; }
    public List<ExpenseStatusTypeMonthlyCountDto> ExpenseStatusTypeMonthlyCounts { get; init; }
    public int ExpenseStatusTypeMonthlyCountsReportYear { get; init; }

    public bool ExpenseActionTypeMonthlyCountsLoading { get; init; }
    public bool ExpenseActionTypeMonthlyCountsInitialized { get; init; }
    public List<ExpenseActionTypeMonthlyCountDto> ExpenseActionTypeMonthlyCounts { get; init; }
    public int ExpenseActionTypeMonthlyCountsReportYear { get; init; }
}