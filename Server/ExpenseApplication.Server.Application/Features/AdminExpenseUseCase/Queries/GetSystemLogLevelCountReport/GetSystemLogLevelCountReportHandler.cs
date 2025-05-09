namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetSystemLogLevelCountReport;

public class GetSystemLogLevelCountReportHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetSystemLogLevelCountReportQuery, GetSystemLogLevelCountReportQueryResult>
{
    public async Task<GetSystemLogLevelCountReportQueryResult> Handle(GetSystemLogLevelCountReportQuery request, CancellationToken cancellationToken)
    {
        var logDbSet = unitOfWork.Set<Log>();

        var systemLogLevelCounts = await logDbSet.AsNoTracking()
            .GroupBy(log => log.Level)
            .Select(grouping => new SystemLogLevelCountDto
            {
                LogLevel = grouping.Key,
                Count = grouping.Count()
            })
            .ToListAsync(cancellationToken);

        return new GetSystemLogLevelCountReportQueryResult(systemLogLevelCounts);
    }
}