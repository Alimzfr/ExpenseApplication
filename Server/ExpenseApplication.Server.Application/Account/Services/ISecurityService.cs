namespace ExpenseApplication.Server.Application.Account.Services;

public interface ISecurityService
{
    string GetSha256Hash(string input);
    Guid CreateCryptographicallySecureGuid();
}