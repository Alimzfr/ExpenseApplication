namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Commands.DeleteAllLogs;

public record DeleteAllLogsCommand : ICommand<DeleteAllLogsCommandResult>;
public record DeleteAllLogsCommandResult(bool IsSuccess);