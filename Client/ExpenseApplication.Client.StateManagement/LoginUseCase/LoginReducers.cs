namespace ExpenseApplication.Client.StateManagement.LoginUseCase;

public class LoginReducers
{
    [ReducerMethod]
    public static LoginState ReduceSetLoginLoadingAction(LoginState state, LoginActions.SetLoginLoadingAction action)
    {
        return state with
        {
            Loading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static LoginState ReduceSubmitLoginUsernamePasswordFormAction(LoginState state, LoginActions.SubmitLoginUsernamePasswordFormAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static LoginState ReduceSubmitRefreshLoginAction(LoginState state, LoginActions.SubmitRefreshLoginAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static LoginState ReduceClearLoginStateAction(LoginState state, LoginActions.ClearLoginStateAction action)
    {
        return state with
        {
            Loading = false
        };
    }
}