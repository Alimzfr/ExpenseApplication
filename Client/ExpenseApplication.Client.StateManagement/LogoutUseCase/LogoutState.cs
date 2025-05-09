namespace ExpenseApplication.Client.StateManagement.LogoutUseCase;

public record LogoutState
{
    public bool Loading { get; init; }
}