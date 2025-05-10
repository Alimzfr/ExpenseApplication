using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Server.Domain.Entities;

/// <summary>
/// Represents an expense form in the application.
/// This entity is used by employees to submit their expenses.
/// </summary>
public class Expense
{
    /// <summary>
    /// The unique identifier for the expense.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The unique identifier for the user who submitted the expense.
    /// </summary>
    public int UserId { get; set; }
    public User User { get; set; }

    /// <summary>
    /// The trace identifier for tracking the expense.
    /// </summary>
    public int TraceId { get; set; }

    /// <summary>
    /// The title of the expense.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The description of the expense.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The currency type of the expense.
    /// All the expense items follow with this currency type.
    /// </summary>
    public CurrencyType CurrencyType { get; set; }

    /// <summary>
    /// Gets or sets the status of the expense (e.g., Pending, Approved, Paid).
    /// </summary>
    public ExpenseStatus ExpenseStatus { get; set; }

    /// <summary>
    /// The username of the person who created the expense.
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    /// The username of the person who last modified the expense.
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// The date and time when the expense was created.
    /// </summary>
    public DateTime CreatedDateTime { get; set; }

    /// <summary>
    /// The date and time when the expense was last modified.
    /// </summary>
    public DateTime? ModifiedDateTime { get; set; }

    /// <summary>
    /// Indicates whether the expense is deleted (soft delete).
    /// </summary>
    public bool IsDeleted { get; set; }

    public ICollection<ExpenseItem> ExpenseItems { get; set; }
    public ICollection<ExpenseTransaction> ExpenseTransactions { get; set; }
}