namespace ExpenseApplication.Client.StateManagement.LogoutUseCase;

public class LogoutStateFeature : Feature<LogoutState>
{
    public override string GetName() => nameof(LogoutState);

    protected override LogoutState GetInitialState()
    {
        return new LogoutState
        {
            Loading = false
        };
    }
}