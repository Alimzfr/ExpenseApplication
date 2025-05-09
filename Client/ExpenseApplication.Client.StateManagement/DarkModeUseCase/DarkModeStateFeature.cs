namespace ExpenseApplication.Client.StateManagement.DarkModeUseCase;

public class DarkModeStateFeature : Feature<DarkModeState>
{
    public override string GetName() => nameof(DarkModeState);

    protected override DarkModeState GetInitialState()
    {
        return new DarkModeState
        {
            Loading = false,
            Initialized = false,
            IsDarkModeEnable = false
        };
    }
}