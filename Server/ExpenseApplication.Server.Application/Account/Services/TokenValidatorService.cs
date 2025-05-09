using Microsoft.IdentityModel.JsonWebTokens;

namespace ExpenseApplication.Server.Application.Account.Services;

public class TokenValidatorService(IUsersService usersService, ITokenStoreService tokenStoreService) : ITokenValidatorService
{
    public async Task ValidateAsync(TokenValidatedContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var claimsIdentity = context.Principal?.Identity as ClaimsIdentity;
        if (claimsIdentity?.Claims is null || !claimsIdentity.Claims.Any())
        {
            context.Fail(failureMessage: "This is not our issued token. It has no claims.");
            return;
        }

        var serialNumberClaim = claimsIdentity.FindFirst(ClaimTypes.SerialNumber);
        if (serialNumberClaim is null)
        {
            context.Fail(failureMessage: "This is not our issued token. It has no serial.");
            return;
        }

        var userIdString = claimsIdentity.FindFirst(ClaimTypes.UserData)?.Value;
        if (!int.TryParse(userIdString, NumberStyles.Number, CultureInfo.InvariantCulture, out var userId))
        {
            context.Fail(failureMessage: "This is not our issued token. It has no user-id.");
            return;
        }

        var user = await usersService.FindUserAsync(userId);
        if (user is null ||
            !string.Equals(user.SerialNumber, serialNumberClaim.Value, StringComparison.Ordinal) ||
            !user.IsActive)
        {
            context.Fail(failureMessage: "This token is expired. Please login again.");
        }

        if (context.SecurityToken is not JsonWebToken accessToken ||
            string.IsNullOrWhiteSpace(accessToken.UnsafeToString()) ||
            !await tokenStoreService.IsValidTokenAsync(accessToken.UnsafeToString(), userId))
        {
            context.Fail(failureMessage: "This token is not in our database.");
            return;
        }

        await usersService.UpdateUserLastActivityDateAsync(userId);
    }
}