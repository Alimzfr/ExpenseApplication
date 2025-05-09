namespace ExpenseApplication.Server.Application.Features.AccountUseCase.Commands.Login;

public class LoginHandler(IUsersService usersService, ITokenStoreService tokenStoreService, ITokenFactoryService tokenFactoryService, IUnitOfWork unitOfWork) : ICommandHandler<LoginCommand, LoginCommandResult>
{
    public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await usersService.FindUserAsync(request.LoginForm.Username, request.LoginForm.Password);
        if (user?.IsActive is not true)
        {
            throw new UserIsNotActiveException("Unauthorized!");
        }

        var jwtTokensData = await tokenFactoryService.CreateJwtTokensAsync(user);
        await tokenStoreService.AddUserTokenAsync(user, jwtTokensData.RefreshTokenSerial, jwtTokensData.AccessToken, refreshTokenSourceSerial: null);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var token = new TokenDto
        {
            AccessToken = jwtTokensData.AccessToken,
            RefreshToken = jwtTokensData.RefreshToken
        };

        return new LoginCommandResult(token);
    }
}