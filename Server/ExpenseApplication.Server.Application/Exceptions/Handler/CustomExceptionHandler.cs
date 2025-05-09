namespace ExpenseApplication.Server.Application.Exceptions.Handler;

/// <summary>
/// Represents a custom exception handler that logs exceptions and returns appropriate HTTP responses.
/// Implements <see cref="IExceptionHandler"/> to handle exceptions in the application.
/// </summary>
/// <param name="logger">The logger used to log exceptions.</param>
public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, exception?.Message);

        var response = exception switch
        {
            UnauthorizedException unauthorizedException => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.Unauthorized,
                ResponseInformation = unauthorizedException.Message
            },
            AccessDeniedException accessDeniedException => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.Forbidden,
                ResponseInformation = accessDeniedException.Message
            },
            FluentValidationException fluentValidationException => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.BadRequest,
                ResponseInformation = string.Join("|", fluentValidationException.Errors.Select(failure => failure.ErrorMessage))
            },
            UserIsNotActiveException userIsNotActiveException => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.Unauthorized,
                ResponseInformation = userIsNotActiveException.Message
            },
            InValidTokenException inValidTokenException => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.Unauthorized,
                ResponseInformation = inValidTokenException.Message
            },
            InValidUserException inValidUserException => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.Unauthorized,
                ResponseInformation = inValidUserException.Message
            },
            BadRequestException badRequestException => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.BadRequest,
                ResponseInformation = badRequestException.Message
            },
            NotFoundException notFoundException => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.NotFound,
                ResponseInformation = notFoundException.Message
            },
            InternalServerException internalServerException => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.InternalServerError,
                ResponseInformation = internalServerException.Message
            },
            _ => new BaseResponseDto
            {
                HttpStatusCode = HttpStatusCode.InternalServerError,
                ResponseInformation = "An error occurred while processing your request."
            }
        };

        context.Response.StatusCode = (int)response.HttpStatusCode;
        await context.Response.WriteAsJsonAsync(response, cancellationToken: cancellationToken);
        return true;
    }
}
