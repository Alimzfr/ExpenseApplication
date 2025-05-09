namespace ExpenseApplication.Server.Application.CQRS;

/// <summary>
/// Represents a handler for a query in the CQRS design pattern.
/// Inherits from <see cref="IRequestHandler{TQuery, TResponse}"/> to handle a query of type <typeparamref name="TQuery"/> and return a response of type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TQuery">The type of the query.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse> where TResponse : notnull
{
}
