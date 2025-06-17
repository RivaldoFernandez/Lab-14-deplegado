using Lab_11_Fernandez.Domain.Entities;

namespace Lab_11_Fernandez.Domain.Interfaces.Repositories;
public interface IUserRoleRepository
{
    Task AddAsync(UserRole userRole);
    Task<bool> ExistsAsync(Guid userId, Guid roleId);
    
    Task SaveChangesAsync();

}

