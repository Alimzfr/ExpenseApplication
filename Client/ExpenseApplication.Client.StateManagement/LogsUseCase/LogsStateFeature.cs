namespace ExpenseApplication.Client.StateManagement.LogsUseCase;

public class LogsStateFeature : Feature<LogsState>
{
    public override string GetName() => nameof(LogsState);

    protected override LogsState GetInitialState()
    {
        return new LogsState
        {
            Loading = false,
            Initialized = false,
            LogRequestFilter = new LogRequestFilterDto(),
            PagingInformation = new PagingInformationDto(),
            Logs = []
        };
    }
}