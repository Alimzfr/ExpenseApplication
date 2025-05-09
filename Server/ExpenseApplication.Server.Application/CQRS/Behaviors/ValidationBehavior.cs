namespace ExpenseApplication.Server.Application.CQRS.Behaviors;

/// <summary>
/// Represents a validation behavior in the MediatR pipeline.
/// This behavior validates the request using the specified validators before passing it to the next handler.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
/// <param name="validators">The collection of validators for the request.</param>
public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.Where(r => r.Errors.Any()).SelectMany(r => r.Errors).ToList();
        if (failures.Any())
        {
            throw new FluentValidationException(failures);
        }

        return await next();
    }
}
