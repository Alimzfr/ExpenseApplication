namespace ExpenseApplication.Server.Domain.Entities;

/// <summary>
/// Represents a role in the application.
/// </summary>
public class Role
{
    /// <summary>
    /// Role ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Role name.
    /// The role names are defined in <see cref="CustomRoleConstants"/>.
    /// </summary>
    public string Name { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}