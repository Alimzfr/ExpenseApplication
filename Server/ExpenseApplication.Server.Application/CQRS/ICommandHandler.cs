namespace ExpenseApplication.Server.Application.CQRS;

/// <summary>
/// Represents a handler for a command in the CQRS design pattern that does not return a response.
/// Inherits from <see cref="ICommandHandler{TCommand, Unit}"/> to handle a command of type <typeparamref name="TCommand"/> with a void response.
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> where TCommand : ICommand<Unit>
{
}

/// <summary>
/// Represents a handler for a command in the CQRS design pattern.
/// Inherits from <see cref="IRequestHandler{TCommand, TResponse}"/> to handle a command of type <typeparamref name="TCommand"/> and return a response of type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse> where TResponse : notnull
{
}
