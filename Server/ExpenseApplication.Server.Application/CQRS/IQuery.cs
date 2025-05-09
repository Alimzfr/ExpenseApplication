namespace ExpenseApplication.Server.Application.CQRS;

/// <summary>
/// Represents a query in the CQRS design pattern.
/// Inherits from <see cref="IRequest{TResponse}"/> to define a request that returns a response of type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}
