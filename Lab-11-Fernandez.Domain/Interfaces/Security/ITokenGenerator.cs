using Lab_11_Fernandez.Domain.Entities;

namespace Lab_11_Fernandez.Domain.Interfaces.Security;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}
