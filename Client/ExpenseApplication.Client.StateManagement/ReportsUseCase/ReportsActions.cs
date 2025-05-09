namespace ExpenseApplication.Client.StateManagement.ReportsUseCase;

public abstract class ReportsActions
{
    public record SetExpenseStatusTypeCountsLoadingAction(bool IsLoading);
    public record SetExpenseStatusTypeCountsInitializedAction(bool IsInitialized);
    public record SetExpenseStatusTypeCountsAction(List<ExpenseStatusTypeCountDto> ExpenseStatusTypeCounts);
    public record LoadExpenseStatusTypeCountsAction(CancellationToken CancellationToken);

    public record SetSystemLogLevelCountsLoadingAction(bool IsLoading);
    public record SetSystemLogLevelCountsInitializedAction(bool IsInitialized);
    public record SetSystemLogLevelCountsAction(List<SystemLogLevelCountDto> SystemLogLevelCounts);
    public record LoadSystemLogLevelCountsAction(CancellationToken CancellationToken);

    public record SetTotalPaidExpensesMonthlyAmountsLoadingAction(bool IsLoading);
    public record SetTotalPaidExpensesMonthlyAmountsInitializedAction(bool IsInitialized);
    public record SetTotalPaidExpensesMonthlyAmountsAction(List<TotalPaidExpensesMonthlyAmountDto> TotalPaidExpensesMonthlyAmounts);
    public record LoadTotalPaidExpensesMonthlyAmountsAction(int Year, CancellationToken CancellationToken);

    public record SetExpenseStatusTypeMonthlyCountsLoadingAction(bool IsLoading);
    public record SetExpenseStatusTypeMonthlyCountsInitializedAction(bool IsInitialized);
    public record SetExpenseStatusTypeMonthlyCountsAction(List<ExpenseStatusTypeMonthlyCountDto> ExpenseStatusTypeMonthlyCounts);
    public record LoadExpenseStatusTypeMonthlyCountsAction(int Year, CancellationToken CancellationToken);

    public record SetExpenseActionTypeMonthlyCountsLoadingAction(bool IsLoading);
    public record SetExpenseActionTypeMonthlyCountsInitializedAction(bool IsInitialized);
    public record SetExpenseActionTypeMonthlyCountsAction(List<ExpenseActionTypeMonthlyCountDto> ExpenseActionTypeMonthlyCounts);
    public record LoadExpenseActionTypeMonthlyCountsAction(int Year, CancellationToken CancellationToken);

    public record ClearReportsStateAction;
}