namespace ExpenseApplication.Client.Services.Services;

public interface IReportService
{
    Task<BaseResponseDto<List<ExpenseStatusTypeCountDto>>> GetExpenseStatusTypeCountReport(CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<List<SystemLogLevelCountDto>>> GetSystemLogLevelCountReport(CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<List<TotalPaidExpensesMonthlyAmountDto>>> GetTotalPaidExpensesMonthlyAmountReport(int year, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<List<ExpenseStatusTypeMonthlyCountDto>>> GetExpenseStatusTypeMonthlyCountReport(int year, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<List<ExpenseActionTypeMonthlyCountDto>>> GetExpenseActionTypeMonthlyCountReport(int year, CancellationToken cancellationToken = default(CancellationToken));
}