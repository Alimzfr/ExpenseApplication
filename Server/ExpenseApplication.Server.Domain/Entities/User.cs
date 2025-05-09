namespace ExpenseApplication.Server.Domain.Entities;


/// <summary>
/// Represents a user in the application.
/// </summary>
public class User
{
    /// <summary>
    /// User ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Username as a credential of user.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Hashed password as a credential of user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Display name of the user, could be fullname.
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// Indicating whether the user is active or not.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// User last logged in DateTime.
    /// </summary>
    public DateTime? LastLoggedIn { get; set; }

    /// <summary>
    /// Every time the user changes his Password, or an admin changes his Roles or stat/IsActive, create a new `SerialNumber` GUID and store it in the Database.
    /// </summary>
    public string? SerialNumber { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<UserToken> UserTokens { get; set; }
    public ICollection<ManagerEmployee> ManagerEmployees { get; set; }
    public ICollection<ManagerEmployee> EmployeeManagers { get; set; }
    public ICollection<Expense> Expenses { get; set; }
    public ICollection<ExpenseTransaction> ExpenseTransactions { get; set; }
}