namespace ExpenseApplication.Client.Services.Services;

public interface ILogService
{
    Task<BaseResponsePagingDto<List<LogDto>>> GetLogsAsync(LogRequestFilterDto logRequestFilter, PagingRequestDto pagingRequest, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<bool>> DeleteAllLogsAsync(CancellationToken cancellationToken = default(CancellationToken));
}