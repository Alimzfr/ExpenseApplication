using System.Runtime.Serialization;

namespace ExpenseApplication.Server.Application.Exceptions;

[Serializable]
public sealed class UnauthorizedException : Exception
{
    public UnauthorizedException()
    {
    }

    public UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public UnauthorizedException(string? message) : base(message)
    {
    }

    public UnauthorizedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}