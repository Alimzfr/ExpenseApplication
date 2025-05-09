namespace ExpenseApplication.Server.Application.Features.AccountUseCase.Commands.Logout;

public class LogoutHandler(ITokenStoreService tokenStoreService, IUnitOfWork unitOfWork) : ICommandHandler<LogoutCommand, LogoutCommandResult>
{
    public async Task<LogoutCommandResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await tokenStoreService.RevokeUserBearerTokensAsync(request.UserId, request.RefreshTokenForm.RefreshToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new LogoutCommandResult(true);
    }
}