namespace ExpenseApplication.Client.Services.Services;

public interface IAccountService
{
    Task<BaseResponseDto<TokenDto>> LoginAsync(string username, string password, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<TokenDto>> LoginAsync(string refreshToken, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<bool>> LogoutAsync(string refreshToken, CancellationToken cancellationToken = default(CancellationToken));
}