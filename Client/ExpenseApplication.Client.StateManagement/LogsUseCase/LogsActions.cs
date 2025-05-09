namespace ExpenseApplication.Client.StateManagement.LogsUseCase;

public abstract class LogsActions
{
    public record SetLogsLoadingAction(bool IsLoading);
    public record SetLogsInitializedAction(bool IsInitialized);
    public record SetLogsAction(List<LogDto> Logs);
    public record SetLogsFilterAction(LogRequestFilterDto LogRequestFilter);
    public record SetLogsPagingInformationAction(PagingInformationDto PagingInformation);
    public record LoadLogsAction(LogRequestFilterDto LogRequestFilter, PagingRequestDto PagingRequest, CancellationToken CancellationToken);
    public record SubmitDeleteAllLogsAction(CancellationToken CancellationToken);
    public record ClearLogsStateAction;
}