namespace ExpenseApplication.Client.StateManagement.LogsUseCase;

public record LogsState
{
    public bool Loading { get; init; }
    public bool Initialized { get; init; }
    public LogRequestFilterDto LogRequestFilter { get; init; }
    public PagingInformationDto PagingInformation { get; init; }
    public List<LogDto> Logs { get; init; }
}