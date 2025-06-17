
using Lab_11_Fernandez.Domain.Entities;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using Lab_11_Fernandez.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab_11_Fernandez.Infrastructure.Repositories;


public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Role> AddAsync(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role;
    }
    public async Task<Role?> GetByIdAsync(Guid roleId)
    {
        return await _context.Roles.FindAsync(roleId);
    }
    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }
    public async Task DeleteAsync(Role role)
    {
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }

}
