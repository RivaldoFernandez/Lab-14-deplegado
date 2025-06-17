

using Lab_11_Fernandez.Domain.Entities;

namespace Lab_11_Fernandez.Domain.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<Role> AddAsync(Role role);
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role?> GetByIdAsync(Guid roleId);
    Task DeleteAsync(Role role);
    
}
