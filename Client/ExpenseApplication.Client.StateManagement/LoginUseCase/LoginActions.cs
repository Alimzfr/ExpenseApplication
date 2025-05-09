namespace ExpenseApplication.Client.StateManagement.LoginUseCase;

public abstract class LoginActions
{
    public record SubmitLoginUsernamePasswordFormAction(LoginFormDto LoginFormUsernamePasswordFormDto, string? ReturnUrl, CancellationToken CancellationToken);
    public record SubmitRefreshLoginAction(CancellationToken CancellationToken);
    public record SetLoginLoadingAction(bool IsLoading);
    public record ClearLoginStateAction;
}