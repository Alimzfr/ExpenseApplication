using Microsoft.IdentityModel.Tokens;

namespace ExpenseApplication.Server.Application.Account.Services;

public class TokenFactoryService(ISecurityService securityService, IRolesService rolesService, IOptionsSnapshot<BearerTokensOptions> configuration, ILogger<TokenFactoryService> logger) : ITokenFactoryService
{
    public async Task<JwtTokensData> CreateJwtTokensAsync(User user)
    {
        var (accessToken, claims) = await createAccessTokenAsync(user);
        var (refreshTokenValue, refreshTokenSerial) = createRefreshToken();
        var jwtTokensData = new JwtTokensData
        {
            AccessToken = accessToken,
            RefreshToken = refreshTokenValue,
            RefreshTokenSerial = refreshTokenSerial,
            Claims = claims
        };
        return jwtTokensData;
    }

    public string? GetRefreshTokenSerial(string refreshTokenValue)
    {
        if (string.IsNullOrWhiteSpace(refreshTokenValue))
        {
            return null;
        }

        ClaimsPrincipal? decodedRefreshTokenPrincipal = null;
        try
        {
            decodedRefreshTokenPrincipal = new JwtSecurityTokenHandler().ValidateToken(refreshTokenValue,
                new TokenValidationParameters
                {
                    ValidIssuer = configuration.Value.Issuer,
                    ValidAudience = configuration.Value.Audience,
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Value.Key)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception?.Message);
        }

        return decodedRefreshTokenPrincipal?.Claims?.FirstOrDefault(c => string.Equals(c.Type, ClaimTypes.SerialNumber, StringComparison.Ordinal))?.Value;
    }

    private (string RefreshToken, string RefreshTokenSerial) createRefreshToken()
    {
        var refreshTokenSerial = securityService.CreateCryptographicallySecureGuid().ToString().Replace(oldValue: "-", newValue: "", StringComparison.Ordinal);
        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new(JwtRegisteredClaimNames.Jti, securityService.CreateCryptographicallySecureGuid().ToString(), ClaimValueTypes.String, configuration.Value.Issuer),
            // Issuer
            new(JwtRegisteredClaimNames.Iss, configuration.Value.Issuer, ClaimValueTypes.String, configuration.Value.Issuer),
            // Issued at
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64, configuration.Value.Issuer),
            // to invalidate the token
            new(ClaimTypes.SerialNumber, refreshTokenSerial, ClaimValueTypes.String, configuration.Value.Issuer),
        };

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Value.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var currentDateTime = DateTime.UtcNow;
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: configuration.Value.Issuer,
            audience: configuration.Value.Audience,
            claims: claims,
            notBefore: currentDateTime,
            expires: currentDateTime.AddMinutes(configuration.Value.RefreshTokenExpirationMinutes),
            signingCredentials: signingCredentials);
        var refreshToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return (refreshToken, refreshTokenSerial);
    }

    private async Task<(string AccessToken, IEnumerable<Claim> Claims)> createAccessTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new(JwtRegisteredClaimNames.Jti, securityService.CreateCryptographicallySecureGuid().ToString(), ClaimValueTypes.String, configuration.Value.Issuer),
            // Issuer
            new(JwtRegisteredClaimNames.Iss, configuration.Value.Issuer, ClaimValueTypes.String, configuration.Value.Issuer),
            // Issued at
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64, configuration.Value.Issuer),
            // userID
            new(ClaimTypes.NameIdentifier, user.Id.ToString(CultureInfo.InvariantCulture), ClaimValueTypes.String, configuration.Value.Issuer),
            // Username
            new(ClaimTypes.Name, user.Username, ClaimValueTypes.String, configuration.Value.Issuer),
            // DisplayName
            new(type: "DisplayName", user.DisplayName ?? string.Empty, ClaimValueTypes.String, configuration.Value.Issuer),
            // to invalidate the token
            new(ClaimTypes.SerialNumber, user.SerialNumber ?? string.Empty, ClaimValueTypes.String, configuration.Value.Issuer),
            // custom data
            new(ClaimTypes.UserData, user.Id.ToString(CultureInfo.InvariantCulture), ClaimValueTypes.String, configuration.Value.Issuer),
        };

        // add roles
        var roles = await rolesService.FindUserRolesAsync(user.Id);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name, ClaimValueTypes.String, configuration.Value.Issuer));
        }

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Value.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var currentDateTime = DateTime.UtcNow;
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: configuration.Value.Issuer,
            audience: configuration.Value.Audience,
            claims: claims,
            notBefore: currentDateTime,
            expires: currentDateTime.AddMinutes(configuration.Value.AccessTokenExpirationMinutes),
            signingCredentials: signingCredentials);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return (accessToken, claims);
    }
}