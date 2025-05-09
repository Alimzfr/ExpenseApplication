using System.Runtime.Serialization;

namespace ExpenseApplication.Server.Application.Exceptions;

[Serializable]
public sealed class AccessDeniedException : Exception
{
    public AccessDeniedException()
    {
    }

    public AccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public AccessDeniedException(string? message) : base(message)
    {
    }

    public AccessDeniedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}