namespace ExpenseApplication.Server.Application.Features.AccountUseCase.Commands.Logout;

public record LogoutCommand(int UserId, RefreshTokenFormDto RefreshTokenForm) : ICommand<LogoutCommandResult>;

public record LogoutCommandResult(bool IsSuccess);
