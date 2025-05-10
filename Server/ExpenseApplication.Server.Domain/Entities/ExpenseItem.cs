namespace ExpenseApplication.Server.Domain.Entities;

/// <summary>
/// Represents an individual expense item in the application.
/// This entity is part of an expense form submitted by an employee.
/// </summary>
public class ExpenseItem
{
    /// <summary>
    /// The unique identifier for the expense item.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The unique identifier for the expense to which this item belongs.
    /// </summary>
    public int ExpenseId { get; set; }
    public Expense Expense { get; set; }

    /// <summary>
    /// The purpose of the expense item (e.g., taxi, food, gas).
    /// </summary>
    public string Purpose { get; set; }

    /// <summary>
    /// The spent amount of the expense item.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// The date and time when the expense item was occurred.
    /// </summary>
    public DateTime OccurrenceDateTime { get; set; }
}