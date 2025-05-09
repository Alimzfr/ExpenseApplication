using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Server.Domain.Entities;

/// <summary>
/// Represents a transaction related to an expense in the application.
/// This entity tracks the actions taken on an expense, such as submit, approve, payment, and so on.
/// </summary>
public class ExpenseTransaction
{
    /// <summary>
    /// The unique identifier for the expense transaction.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The unique identifier for the user associated with this transaction.
    /// </summary>
    public int UserId { get; set; }
    public User User { get; set; }

    /// <summary>
    /// The unique identifier for the expense associated with this transaction.
    /// </summary>
    public int ExpenseId { get; set; }
    public Expense Expense { get; set; }

    /// <summary>
    /// The type of action performed on the expense (e.g., submit, approve, payment).
    /// </summary>
    public ExpenseActionType ActionType { get; set; }

    /// <summary>
    /// The date and time when the action was performed.
    /// </summary>
    public DateTime ActionDateTime { get; set; }

    /// <summary>
    /// Any additional comments related to the transaction.
    /// </summary>
    public string? Comments { get; set; }
}