namespace ExpenseApplication.Server.Domain.Entities;

/// <summary>
/// Represents a token associated with a user for authentication and authorization JWT purposes.
/// </summary>
public class UserToken
{
    /// <summary>
    /// The unique identifier for the user token.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The unique identifier for the user associated with this token.
    /// </summary>
    public int UserId { get; set; }
    public User User { get; set; }

    /// <summary>
    /// The hash of the JWT access token.
    /// </summary>
    public string? AccessTokenHash { get; set; }

    /// <summary>
    /// The expiration date and time of the JWT access token.
    /// </summary>
    public DateTime AccessTokenExpiresDateTime { get; set; }

    /// <summary>
    /// The hash of the refresh token ID.
    /// </summary>
    public string RefreshTokenIdHash { get; set; }

    /// <summary>
    /// The source hash of the refresh token, if any.
    /// </summary>
    public string? RefreshTokenIdHashSource { get; set; }

    /// <summary>
    /// The expiration date and time of the refresh token.
    /// </summary>
    public DateTime RefreshTokenExpiresDateTime { get; set; }
}