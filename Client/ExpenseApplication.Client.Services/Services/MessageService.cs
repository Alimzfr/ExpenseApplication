namespace ExpenseApplication.Client.Services.Services;

public class MessageService(ISnackbar snackbar) : IMessageService
{
    public void Show(string message, MessageSeverityType messageSeverityType)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        var messageList = message.Split("|", StringSplitOptions.RemoveEmptyEntries);
        foreach (var subMessage in messageList)
        {
            switch (messageSeverityType)
            {
                case MessageSeverityType.Normal:
                    snackbar.Add(subMessage);
                    break;
                case MessageSeverityType.Info:
                    snackbar.Add(subMessage, Severity.Info);
                    break;
                case MessageSeverityType.Success:
                    snackbar.Add(subMessage, Severity.Success);
                    break;
                case MessageSeverityType.Warning:
                    snackbar.Add(subMessage, Severity.Warning);
                    break;
                case MessageSeverityType.Error:
                    snackbar.Add(subMessage, Severity.Error);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageSeverityType), messageSeverityType, $"{nameof(messageSeverityType)} is out of range!");
            }
        }
    }
}