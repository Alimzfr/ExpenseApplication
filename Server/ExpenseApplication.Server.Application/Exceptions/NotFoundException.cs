using System.Runtime.Serialization;

namespace ExpenseApplication.Server.Application.Exceptions;

[Serializable]
public sealed class NotFoundException : Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
