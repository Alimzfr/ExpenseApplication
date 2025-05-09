namespace ExpenseApplication.Server.Application.CQRS;

/// <summary>
/// Represents a command in the CQRS design pattern that does not return a response.
/// Inherits from <see cref="ICommand{Unit}"/> to define a command with a void response.
/// </summary>
public interface ICommand : ICommand<Unit>
{
}

/// <summary>
/// Represents a command in the CQRS design pattern.
/// Inherits from <see cref="IRequest{TResponse}"/> to define a request that returns a response of type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
