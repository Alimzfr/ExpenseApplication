namespace ExpenseApplication.Client.StateManagement.DarkModeUseCase;

public class DarkModeEffects(IDarkModeService darkModeService)
{
    [EffectMethod]
    public async Task EffectLoadIsDarkModeEnableAction(DarkModeActions.LoadIsDarkModeEnableAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new DarkModeActions.SetDarkModeLoadingAction(true));
        var isDarkMode = await darkModeService.GetDarkModeAsync(action.CancellationToken);
        dispatcher.Dispatch(new DarkModeActions.SetIsDarkModeEnableAction(isDarkMode));
        dispatcher.Dispatch(new DarkModeActions.SetDarkModeInitializedAction(true));
        dispatcher.Dispatch(new DarkModeActions.SetDarkModeLoadingAction(false));
    }

    [EffectMethod]
    public async Task EffectSwitchIsDarkModeEnableAction(DarkModeActions.SwitchIsDarkModeEnableAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new DarkModeActions.SetDarkModeLoadingAction(true));
        await darkModeService.SetDarkModeAsync(action.IsDarkModeEnable, action.CancellationToken);
        dispatcher.Dispatch(new DarkModeActions.SetIsDarkModeEnableAction(action.IsDarkModeEnable));
        dispatcher.Dispatch(new DarkModeActions.SetDarkModeInitializedAction(true));
        dispatcher.Dispatch(new DarkModeActions.SetDarkModeLoadingAction(false));
    }
}