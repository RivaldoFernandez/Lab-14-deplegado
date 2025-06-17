using Lab_11_Fernandez.Domain.Entities;
using Lab_11_Fernandez.Infrastructure.Context;

namespace Lab_11_Fernandez.Infrastructure.Repositories;

using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly ApplicationDbContext _context;

    public UserRoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserRole userRole)
    {
        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid userId, Guid roleId)
    {
        return await _context.UserRoles.AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
