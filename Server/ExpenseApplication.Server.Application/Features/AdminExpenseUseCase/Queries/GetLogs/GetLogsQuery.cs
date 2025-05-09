namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetLogs;

public record GetLogsQuery(LogRequestFilterDto LogRequestFilter, PagingRequestDto PagingRequest) : IQuery<GetLogsQueryResult>;
public record GetLogsQueryResult(List<LogDto> Logs, PagingInformationDto PagingInformation);