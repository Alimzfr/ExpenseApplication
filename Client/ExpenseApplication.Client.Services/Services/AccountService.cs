namespace ExpenseApplication.Client.Services.Services;

public class AccountService(IApiService apiService) : IAccountService
{
    public async Task<BaseResponseDto<TokenDto>> LoginAsync(string username, string password, CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Post<LoginFormDto, BaseResponseDto<TokenDto>>(ApiAddressConstants.Login,
            new LoginFormDto
            {
                Username = username,
                Password = password
            },
            cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<TokenDto>> LoginAsync(string refreshToken, CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Post<RefreshTokenFormDto, BaseResponseDto<TokenDto>>(ApiAddressConstants.RefreshToken,
            new RefreshTokenFormDto
            {
                RefreshToken = refreshToken
            },
            cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<bool>> LogoutAsync(string refreshToken, CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Post<RefreshTokenFormDto, BaseResponseDto<bool>>(ApiAddressConstants.Logout,
            new RefreshTokenFormDto
            {
                RefreshToken = refreshToken
            },
            cancellationToken);
        return response;
    }
}