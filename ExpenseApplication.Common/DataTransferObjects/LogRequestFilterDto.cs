namespace ExpenseApplication.Common.DataTransferObjects;

public class LogRequestFilterDto
{
    public DateTime? StartTimeStamp { get; set; }
    public DateTime? EndTimeStamp { get; set; }
    public string? Message { get; set; }
    public string? Level { get; set; }
}