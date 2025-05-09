namespace ExpenseApplication.Client.StateManagement.LogoutUseCase;

public class LogoutReducers
{
    [ReducerMethod]
    public static LogoutState ReduceSetLogoutLoadingAction(LogoutState state, LogoutActions.SetLogoutLoadingAction action)
    {
        return state with
        {
            Loading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static LogoutState ReduceSubmitLogoutAction(LogoutState state, LogoutActions.SubmitLogoutAction action)
    {
        return state;
    }
}