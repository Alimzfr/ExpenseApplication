namespace ExpenseApplication.Client.StateManagement.DarkModeUseCase;

public abstract class DarkModeActions
{
    public record SetDarkModeLoadingAction(bool IsLoading);
    public record SetDarkModeInitializedAction(bool IsInitialized);
    public record SetIsDarkModeEnableAction(bool IsDarkModeEnable);
    public record SwitchIsDarkModeEnableAction(bool IsDarkModeEnable, CancellationToken CancellationToken);
    public record LoadIsDarkModeEnableAction(CancellationToken CancellationToken);
    public record ClearDarkModeStateAction;
}