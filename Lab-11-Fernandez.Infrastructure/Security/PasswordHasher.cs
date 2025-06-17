using Microsoft.AspNetCore.Identity;
using Lab_11_Fernandez.Domain.Interfaces.Security;

namespace Lab_11_Fernandez.Infrastructure.Security;

// IMPLEMENTA explícitamente la interfaz
public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<object> _hasher = new();

    public string HashPassword(string password)
    {
        return _hasher.HashPassword(null, password);
    }

    // Este método es adicional, útil si luego deseas validación
    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var result = _hasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}