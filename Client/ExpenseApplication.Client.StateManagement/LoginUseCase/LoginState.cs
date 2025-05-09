namespace ExpenseApplication.Client.StateManagement.LoginUseCase;

public record LoginState
{
    public bool Loading { get; init; }
}