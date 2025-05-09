namespace ExpenseApplication.Server.Domain.Entities;

/// <summary>
/// Represents the association between a user and a role in the application.
/// </summary>
public class UserRole
{
    /// <summary>
    /// The unique identifier for the User.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// The unique identifier for the Role.
    /// </summary>
    public int RoleId { get; set; }

    public User User { get; set; }
    public Role Role { get; set; }
}