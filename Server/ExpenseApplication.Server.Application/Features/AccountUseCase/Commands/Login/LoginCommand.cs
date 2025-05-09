namespace ExpenseApplication.Server.Application.Features.AccountUseCase.Commands.Login;

public record LoginCommand(LoginFormDto LoginForm) :ICommand<LoginCommandResult>;

public record LoginCommandResult(TokenDto Token);