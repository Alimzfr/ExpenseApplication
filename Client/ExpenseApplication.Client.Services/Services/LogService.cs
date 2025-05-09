namespace ExpenseApplication.Client.Services.Services;

public class LogService(IApiService apiService) : ILogService
{
    public async Task<BaseResponsePagingDto<List<LogDto>>> GetLogsAsync(LogRequestFilterDto logRequestFilter, PagingRequestDto pagingRequest, CancellationToken cancellationToken = default(CancellationToken))
    {
        const string url = "api/Admin/GetLogs";
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(logRequestFilter.Level), logRequestFilter.Level },
            { nameof(logRequestFilter.Message), logRequestFilter.Message },
            { nameof(logRequestFilter.StartTimeStamp), logRequestFilter.StartTimeStamp?.ToString() },
            { nameof(logRequestFilter.EndTimeStamp), logRequestFilter.EndTimeStamp?.ToString() },
            { nameof(pagingRequest.PageSize), pagingRequest.PageSize.ToString() },
            { nameof(pagingRequest.PageNumber), pagingRequest.PageNumber.ToString() }
        };
        var response = await apiService.Get<BaseResponsePagingDto<List<LogDto>>>(url, queryParams, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<bool>> DeleteAllLogsAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Delete<BaseResponseDto<bool>>(ApiAddressConstants.AdminDeleteAllLogs, null, cancellationToken);
        return response;
    }
}