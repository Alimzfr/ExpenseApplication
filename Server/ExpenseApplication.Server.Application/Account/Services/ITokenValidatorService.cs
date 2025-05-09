namespace ExpenseApplication.Server.Application.Account.Services;

public interface ITokenValidatorService
{
    Task ValidateAsync(TokenValidatedContext context);
}