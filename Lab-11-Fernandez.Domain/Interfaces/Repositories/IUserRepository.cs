using Lab_11_Fernandez.Domain.Entities;

namespace Lab_11_Fernandez.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<bool> UserExistsAsync(string username);
    Task AddUserAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByIdAsync(Guid userId);
    Task<IEnumerable<User>> GetAllAsync();
    
}