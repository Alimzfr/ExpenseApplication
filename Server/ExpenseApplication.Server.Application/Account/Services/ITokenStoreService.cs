﻿namespace ExpenseApplication.Server.Application.Account.Services;

public interface ITokenStoreService
{
    Task AddUserTokenAsync(UserToken userToken);
    Task AddUserTokenAsync(User user, string refreshTokenSerial, string accessToken, string? refreshTokenSourceSerial);
    Task<bool> IsValidTokenAsync(string accessToken, int userId);
    Task DeleteExpiredTokensAsync();
    Task<UserToken?> FindTokenAsync(string refreshTokenValue);
    Task DeleteTokenAsync(string refreshTokenValue);
    Task DeleteTokensWithSameRefreshTokenSourceAsync(string? refreshTokenIdHashSource);
    Task InvalidateUserTokensAsync(int userId);
    Task RevokeUserBearerTokensAsync(int? userId, string refreshToken);
}