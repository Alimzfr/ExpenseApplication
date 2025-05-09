namespace ExpenseApplication.Server.Application.Account.Services;

public class TokenStoreService(
    IUnitOfWork unitOfWork,
    ISecurityService securityService,
    IOptionsSnapshot<BearerTokensOptions> configuration,
    ITokenFactoryService tokenFactoryService) : ITokenStoreService
{
    private readonly DbSet<UserToken> _userTokenDbSet = unitOfWork.Set<UserToken>();

    public async Task AddUserTokenAsync(UserToken userToken)
    {
        if (!configuration.Value.AllowMultipleLoginsFromTheSameUser)
        {
            await InvalidateUserTokensAsync(userToken.UserId);
        }

        await DeleteTokensWithSameRefreshTokenSourceAsync(userToken.RefreshTokenIdHashSource);
        _userTokenDbSet.Add(userToken);
    }

    public async Task AddUserTokenAsync(User user, string refreshTokenSerial, string accessToken,
        string? refreshTokenSourceSerial)
    {
        ArgumentNullException.ThrowIfNull(user);
        var currentDateTime = DateTime.UtcNow;
        var userToken = new UserToken
        {
            UserId = user.Id,
            // Refresh token handles should be treated as secrets and should be stored hashed
            RefreshTokenIdHash = securityService.GetSha256Hash(refreshTokenSerial),
            RefreshTokenIdHashSource = string.IsNullOrWhiteSpace(refreshTokenSourceSerial)
                ? null
                : securityService.GetSha256Hash(refreshTokenSourceSerial),
            AccessTokenHash = securityService.GetSha256Hash(accessToken),
            RefreshTokenExpiresDateTime = currentDateTime.AddMinutes(configuration.Value.RefreshTokenExpirationMinutes),
            AccessTokenExpiresDateTime = currentDateTime.AddMinutes(configuration.Value.AccessTokenExpirationMinutes)
        };

        await AddUserTokenAsync(userToken);
    }

    public async Task DeleteExpiredTokensAsync()
    {
        var currentDateTime = DateTime.UtcNow;
        await _userTokenDbSet.Where(x => x.RefreshTokenExpiresDateTime < currentDateTime)
            .ForEachAsync(userToken => _userTokenDbSet.Remove(userToken));
    }

    public async Task DeleteTokenAsync(string refreshTokenValue)
    {
        var userToken = await FindTokenAsync(refreshTokenValue);

        if (userToken is not null)
        {
            _userTokenDbSet.Remove(userToken);
        }
    }

    public async Task DeleteTokensWithSameRefreshTokenSourceAsync(string? refreshTokenIdHashSource)
    {
        if (string.IsNullOrWhiteSpace(refreshTokenIdHashSource))
        {
            return;
        }

        await _userTokenDbSet
            .Where(userToken => userToken.RefreshTokenIdHashSource == refreshTokenIdHashSource ||
                                (userToken.RefreshTokenIdHash == refreshTokenIdHashSource &&
                                 userToken.RefreshTokenIdHashSource == null))
            .ForEachAsync(userToken => _userTokenDbSet.Remove(userToken));
    }

    public async Task RevokeUserBearerTokensAsync(int? userId, string refreshToken)
    {
        if (userId is not null && userId is not default(int))
        {
            if (configuration.Value.AllowSignoutAllUserActiveClients)
            {
                await InvalidateUserTokensAsync(userId.Value);
            }
        }

        if (!string.IsNullOrWhiteSpace(refreshToken))
        {
            var refreshTokenSerial = tokenFactoryService.GetRefreshTokenSerial(refreshToken);

            if (!string.IsNullOrWhiteSpace(refreshTokenSerial))
            {
                var refreshTokenIdHashSource = securityService.GetSha256Hash(refreshTokenSerial);
                await DeleteTokensWithSameRefreshTokenSourceAsync(refreshTokenIdHashSource);
            }
        }

        await DeleteExpiredTokensAsync();
    }

    public Task<UserToken?> FindTokenAsync(string refreshTokenValue)
    {
        if (string.IsNullOrWhiteSpace(refreshTokenValue))
        {
            return Task.FromResult<UserToken?>(result: null);
        }

        var refreshTokenSerial = tokenFactoryService.GetRefreshTokenSerial(refreshTokenValue);
        if (string.IsNullOrWhiteSpace(refreshTokenSerial))
        {
            return Task.FromResult<UserToken?>(result: null);
        }

        var refreshTokenIdHash = securityService.GetSha256Hash(refreshTokenSerial);
        return _userTokenDbSet.Include(x => x.User).FirstOrDefaultAsync(x => x.RefreshTokenIdHash == refreshTokenIdHash);
    }

    public async Task InvalidateUserTokensAsync(int userId)
    {
        await _userTokenDbSet.Where(x => x.UserId == userId).ForEachAsync(userToken => _userTokenDbSet.Remove(userToken));
    }

    public async Task<bool> IsValidTokenAsync(string accessToken, int userId)
    {
        var accessTokenHash = securityService.GetSha256Hash(accessToken);
        var userToken = await _userTokenDbSet.FirstOrDefaultAsync(x => x.AccessTokenHash == accessTokenHash && x.UserId == userId);
        return userToken?.AccessTokenExpiresDateTime >= DateTime.UtcNow;
    }
}