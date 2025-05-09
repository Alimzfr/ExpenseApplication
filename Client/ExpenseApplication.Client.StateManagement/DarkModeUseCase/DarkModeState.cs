namespace ExpenseApplication.Client.StateManagement.DarkModeUseCase;

public record DarkModeState
{
    public bool Loading { get; init; }
    public bool Initialized { get; init; }
    public bool IsDarkModeEnable { get; init; }
}