namespace ExpenseApplication.Client.StateManagement.LoginUseCase;

public class LoginStateFeature : Feature<LoginState>
{
    public override string GetName() => nameof(LoginState);

    protected override LoginState GetInitialState()
    {
        return new LoginState
        {
            Loading = false
        };
    }
}