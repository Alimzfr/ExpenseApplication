namespace ExpenseApplication.Client.Services.Services;

public class ReportService(IApiService apiService) : IReportService
{
    public async Task<BaseResponseDto<List<ExpenseStatusTypeCountDto>>> GetExpenseStatusTypeCountReport(CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Get<BaseResponseDto<List<ExpenseStatusTypeCountDto>>>(ApiAddressConstants.AdminGetExpenseStatusTypeCountReport, null, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<List<SystemLogLevelCountDto>>> GetSystemLogLevelCountReport(CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Get<BaseResponseDto<List<SystemLogLevelCountDto>>>(ApiAddressConstants.AdminGetSystemLogLevelCountReport, null, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<List<TotalPaidExpensesMonthlyAmountDto>>> GetTotalPaidExpensesMonthlyAmountReport(int year, CancellationToken cancellationToken = default(CancellationToken))
    {
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(year), year.ToString() }
        };
        var response = await apiService.Get<BaseResponseDto<List<TotalPaidExpensesMonthlyAmountDto>>>(ApiAddressConstants.AdminGetTotalPaidExpensesMonthlyAmountReport, queryParams, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<List<ExpenseStatusTypeMonthlyCountDto>>> GetExpenseStatusTypeMonthlyCountReport(int year, CancellationToken cancellationToken = default(CancellationToken))
    {
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(year), year.ToString() }
        };
        var response = await apiService.Get<BaseResponseDto<List<ExpenseStatusTypeMonthlyCountDto>>>(ApiAddressConstants.AdminGetExpenseStatusTypeMonthlyCountReport, queryParams, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<List<ExpenseActionTypeMonthlyCountDto>>> GetExpenseActionTypeMonthlyCountReport(int year, CancellationToken cancellationToken = default(CancellationToken))
    {
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(year), year.ToString() }
        };
        var response = await apiService.Get<BaseResponseDto<List<ExpenseActionTypeMonthlyCountDto>>>(ApiAddressConstants.AdminGetExpenseActionTypeMonthlyCountReport, queryParams, cancellationToken);
        return response;
    }
}