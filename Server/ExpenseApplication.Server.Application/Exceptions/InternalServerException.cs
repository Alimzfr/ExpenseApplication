using System.Runtime.Serialization;

namespace ExpenseApplication.Server.Application.Exceptions;

[Serializable]
public sealed class InternalServerException : Exception
{
    public InternalServerException()
    {
    }

    public InternalServerException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public InternalServerException(string? message) : base(message)
    {
    }

    public InternalServerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
