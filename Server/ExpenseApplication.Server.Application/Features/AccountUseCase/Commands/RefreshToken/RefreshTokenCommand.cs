namespace ExpenseApplication.Server.Application.Features.AccountUseCase.Commands.RefreshToken;

public record RefreshTokenCommand(RefreshTokenFormDto RefreshTokenForm) : ICommand<RefreshTokenCommandResult>;

public record RefreshTokenCommandResult(TokenDto Token);