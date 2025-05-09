namespace ExpenseApplication.Server.Application.Account.Services;

public interface ITokenFactoryService
{
    Task<JwtTokensData> CreateJwtTokensAsync(User user);
    string? GetRefreshTokenSerial(string refreshTokenValue);
}