namespace ExpenseApplication.Server.Domain.Entities;

/// <summary>
/// Represents a log entry in the application.
/// This entity is used to control the log table, manage auto migrations, and generate reports.
/// Although Serilog creates the log table automatically based on its configuration, this entity provides additional control.
/// </summary>
public class Log
{
    public int Id { get; set; }
    public string? Message { get; set; }
    public string? Level { get; set; }
    public DateTime? TimeStamp { get; set; }
    public string? Exception { get; set; }
    public string? LogEvent { get; set; }
}