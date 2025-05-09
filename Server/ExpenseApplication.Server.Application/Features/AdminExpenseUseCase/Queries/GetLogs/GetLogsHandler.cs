namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetLogs;

public class GetLogsHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetLogsQuery, GetLogsQueryResult>
{
    public async Task<GetLogsQueryResult> Handle(GetLogsQuery request, CancellationToken cancellationToken)
    {
        var logDbSet = unitOfWork.Set<Log>();

        var filteredDataQuery = logDbSet.AsNoTracking()
            .Where(log => log.Level != null && (string.IsNullOrEmpty(request.LogRequestFilter.Level) || log.Level.Contains(request.LogRequestFilter.Level)))
            .Where(log => log.Message != null && (string.IsNullOrEmpty(request.LogRequestFilter.Message) || log.Message.Contains(request.LogRequestFilter.Message)))
            .Where(log => log.TimeStamp != null && (!request.LogRequestFilter.StartTimeStamp.HasValue || log.TimeStamp.Value.Date >= request.LogRequestFilter.StartTimeStamp.Value.Date))
            .Where(log => log.TimeStamp != null && (!request.LogRequestFilter.EndTimeStamp.HasValue || log.TimeStamp.Value.Date <= request.LogRequestFilter.EndTimeStamp.Value.Date));

        var totalCount = await filteredDataQuery.AsNoTracking().CountAsync(cancellationToken);
        var logs = await filteredDataQuery.AsNoTracking()
            .OrderByDescending(e => e.TimeStamp)
            .Skip((request.PagingRequest.PageNumber - 1) * request.PagingRequest.PageSize)
            .Take(request.PagingRequest.PageSize)
            .ToListAsync(cancellationToken);

        var mappedLogs = mapper.Map<List<Log>, List<LogDto>>(logs);
        var pagingInformation = new PagingInformationDto
        {
            TotalCount = totalCount,
            PageSize = request.PagingRequest.PageSize,
            PageNumber = request.PagingRequest.PageNumber
        };
        return new GetLogsQueryResult(mappedLogs, pagingInformation);
    }
}