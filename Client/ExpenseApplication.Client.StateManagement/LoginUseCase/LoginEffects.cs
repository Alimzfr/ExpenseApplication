namespace ExpenseApplication.Client.StateManagement.LoginUseCase;

public class LoginEffects(IAccountService accountService, AuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager, ICustomLocalStorageService appLocalStorageService, IMessageService messageService)
{
    [EffectMethod]
    public async Task EffectSubmitRefreshLoginAction(LoginActions.SubmitRefreshLoginAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LoginActions.SetLoginLoadingAction(true));
        var refreshToken = await appLocalStorageService.GetItemAsync<string?>(LocalStorageConstants.RefreshToken);
        if (refreshToken is not null)
        {
            var result = await accountService.LoginAsync(refreshToken, action.CancellationToken);
            if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
            {
                messageService.Show(result.ResponseInformation, MessageSeverityType.Success);
                await appLocalStorageService.SetItemAsync(LocalStorageConstants.AccessToken, result.Data?.AccessToken);
                await appLocalStorageService.SetItemAsync(LocalStorageConstants.RefreshToken, result.Data?.RefreshToken);
                await (authenticationStateProvider as CustomAuthStateProvider)?.NotifyAuthenticationStateChanged();
                dispatcher.Dispatch(new LoginActions.SetLoginLoadingAction(false));
            }
            else
            {
                messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
                dispatcher.Dispatch(new LogoutActions.SubmitLogoutAction(action.CancellationToken));
                dispatcher.Dispatch(new LoginActions.SetLoginLoadingAction(false));
            }
        }
        else
        {
            messageService.Show("RefreshToken does not exist!", MessageSeverityType.Error);
            dispatcher.Dispatch(new LogoutActions.SubmitLogoutAction(action.CancellationToken));
            dispatcher.Dispatch(new LoginActions.SetLoginLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectSubmitLoginUsernamePasswordFormAction(LoginActions.SubmitLoginUsernamePasswordFormAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LoginActions.SetLoginLoadingAction(true));
        var result = await accountService.LoginAsync(action.LoginFormUsernamePasswordFormDto.Username, action.LoginFormUsernamePasswordFormDto.Password, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            await appLocalStorageService.SetItemAsync(LocalStorageConstants.AccessToken, result.Data?.AccessToken);
            await appLocalStorageService.SetItemAsync(LocalStorageConstants.RefreshToken, result.Data?.RefreshToken);
            await (authenticationStateProvider as CustomAuthStateProvider)?.NotifyAuthenticationStateChanged();
            messageService.Show(result.ResponseInformation, MessageSeverityType.Success);
            navigationManager.NavigateTo(action.ReturnUrl ?? PageAddressConstants.HomePage);
            dispatcher.Dispatch(new LoginActions.SetLoginLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new LoginActions.SetLoginLoadingAction(false));
        }
    }
}