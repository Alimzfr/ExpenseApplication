using ExpenseApplication.Client.StateManagement.DarkModeUseCase;

namespace ExpenseApplication.Client.StateManagement.LogoutUseCase;

public class LogoutEffects(AuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager, HttpClient httpClient, ICustomLocalStorageService appLocalStorageService, IAccountService accountService)
{
    [EffectMethod]
    public async Task EffectSubmitLogoutAction(LogoutActions.SubmitLogoutAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogoutActions.SetLogoutLoadingAction(true));
        var refreshToken = await appLocalStorageService.GetItemAsync<string?>(LocalStorageConstants.RefreshToken);
        await accountService.LogoutAsync(refreshToken, action.CancellationToken);
        httpClient.DefaultRequestHeaders.Authorization = null;
        await appLocalStorageService.RemoveItemsAsync([LocalStorageConstants.AccessToken, LocalStorageConstants.RefreshToken]);
        await (authenticationStateProvider as CustomAuthStateProvider)?.NotifyAuthenticationStateChanged()!;
        navigationManager.NavigateTo(PageAddressConstants.LoginPage);
        dispatcher.Dispatch(new LoginActions.ClearLoginStateAction());
        dispatcher.Dispatch(new EmployeeExpensesActions.ClearEmployeeExpensesStateAction());
        dispatcher.Dispatch(new ManagerExpensesActions.ClearManagerExpensesStateAction());
        dispatcher.Dispatch(new AccountantExpensesActions.ClearAccountantExpensesStateAction());
        dispatcher.Dispatch(new AdminExpensesActions.ClearAdminExpensesStateAction());
        dispatcher.Dispatch(new ExpenseTransactionsActions.ClearEmployeeExpensesStateAction());
        dispatcher.Dispatch(new LogsActions.ClearLogsStateAction());
        dispatcher.Dispatch(new ReportsActions.ClearReportsStateAction());
        dispatcher.Dispatch(new LogoutActions.SetLogoutLoadingAction(false));
    }
}