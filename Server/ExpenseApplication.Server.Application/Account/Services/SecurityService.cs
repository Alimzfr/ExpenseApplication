using System.Security.Cryptography;

namespace ExpenseApplication.Server.Application.Account.Services;

public class SecurityService : ISecurityService
{
    private readonly RandomNumberGenerator _randomNumberGenerator = RandomNumberGenerator.Create();

    public string GetSha256Hash(string input)
    {
        var byteValue = Encoding.UTF8.GetBytes(input);
        var byteHash = SHA256.HashData(byteValue);
        return Convert.ToBase64String(byteHash);
    }

    public Guid CreateCryptographicallySecureGuid()
    {
        var bytes = new byte[16];
        _randomNumberGenerator.GetBytes(bytes);
        return new Guid(bytes);
    }
}