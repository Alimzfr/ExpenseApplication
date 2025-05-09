namespace ExpenseApplication.Client.Services.Services;

public interface IMessageService
{
    void Show(string message, MessageSeverityType messageSeverityType);
}