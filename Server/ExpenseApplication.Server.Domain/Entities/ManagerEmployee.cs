namespace ExpenseApplication.Server.Domain.Entities;

/// <summary>
/// Represents the relationship between a manager and an employee in the application.
/// The relation could be n to n.
/// Each manager could have many employees and each employee could have many managers.
/// </summary>
public class ManagerEmployee
{
    /// <summary>
    /// The unique identifier for the manager.
    /// </summary>
    public int ManagerId { get; set; }
    public User Manager { get; set; }

    /// <summary>
    /// The unique identifier for the employee.
    /// </summary>
    public int EmployeeId { get; set; }
    public User Employee { get; set; }
}