using System.Runtime.Serialization;

namespace ExpenseApplication.Server.Application.Exceptions;

[Serializable]
public sealed class InValidTokenException : Exception
{
    public InValidTokenException()
    {
    }

    public InValidTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public InValidTokenException(string? message) : base(message)
    {
    }

    public InValidTokenException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}