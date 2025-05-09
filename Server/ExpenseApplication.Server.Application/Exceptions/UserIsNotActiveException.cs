using System.Runtime.Serialization;

namespace ExpenseApplication.Server.Application.Exceptions;

[Serializable]
public sealed class UserIsNotActiveException : Exception
{
    public UserIsNotActiveException()
    {
    }

    public UserIsNotActiveException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public UserIsNotActiveException(string? message) : base(message)
    {
    }

    public UserIsNotActiveException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}