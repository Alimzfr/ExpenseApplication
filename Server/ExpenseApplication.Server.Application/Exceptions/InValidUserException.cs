using System.Runtime.Serialization;

namespace ExpenseApplication.Server.Application.Exceptions;

[Serializable]
public sealed class InValidUserException : Exception
{
    public InValidUserException()
    {
    }

    public InValidUserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public InValidUserException(string? message) : base(message)
    {
    }

    public InValidUserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}