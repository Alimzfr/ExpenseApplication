namespace ExpenseApplication.Client.StateManagement.LogoutUseCase;

public abstract class LogoutActions
{
    public record SetLogoutLoadingAction(bool IsLoading);
    public record SubmitLogoutAction(CancellationToken CancellationToken);
}