namespace ExpenseApplication.Server.Application.Features.AccountUseCase.Commands.RefreshToken;

public class RefreshTokenHandler(ITokenStoreService tokenStoreService, ITokenFactoryService tokenFactoryService, IUnitOfWork unitOfWork) : ICommandHandler<RefreshTokenCommand, RefreshTokenCommandResult>
{
    public async Task<RefreshTokenCommandResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var userToken = await tokenStoreService.FindTokenAsync(request.RefreshTokenForm.RefreshToken);
        if (userToken is null)
        {
            throw new InValidTokenException("Token is not valid.");
        }

        var jwtTokensData = await tokenFactoryService.CreateJwtTokensAsync(userToken.User);
        await tokenStoreService.AddUserTokenAsync(userToken.User, jwtTokensData.RefreshTokenSerial, jwtTokensData.AccessToken, tokenFactoryService.GetRefreshTokenSerial(request.RefreshTokenForm.RefreshToken));
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var token = new TokenDto
        {
            AccessToken = jwtTokensData.AccessToken,
            RefreshToken = jwtTokensData.RefreshToken
        };

        return new RefreshTokenCommandResult(token);
    }
}