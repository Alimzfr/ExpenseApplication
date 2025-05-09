namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Commands.DeleteAllLogs;

public class DeleteAllLogsHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeleteAllLogsCommand, DeleteAllLogsCommandResult>
{
    public async Task<DeleteAllLogsCommandResult> Handle(DeleteAllLogsCommand request, CancellationToken cancellationToken)
    {
        var logDbSet = unitOfWork.Set<Log>();

        await logDbSet.BulkDeleteAsync(logDbSet, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteAllLogsCommandResult(true);
    }
}