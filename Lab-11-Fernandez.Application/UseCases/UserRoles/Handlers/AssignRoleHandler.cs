// using Lab_11_Fernandez.Application.UseCases.UserRoles.Commands;
//
// namespace Lab_11_Fernandez.Application.UseCases.UserRoles.Handlers;
//
// using Lab_11_Fernandez.Domain.Entities;
// using Lab_11_Fernandez.Domain.Interfaces.Repositories;
// using MediatR;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
//
// public class AssignRoleHandler : IRequestHandler<AssignRoleCommand, string>
// {
//     private readonly IUserRoleRepository _userRoleRepository;
//
//     public AssignRoleHandler(IUserRoleRepository userRoleRepository)
//     {
//         _userRoleRepository = userRoleRepository;
//     }
//
//     public async Task<string> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
//     {
//         // Verificar si ya existe esa asignación para evitar duplicados
//         bool exists = await _userRoleRepository.ExistsAsync(request.UserId, request.RoleId);
//         if (exists)
//             return "El rol ya está asignado a este usuario.";
//
//         var userRole = new UserRole
//         {
//             UserId = request.UserId,
//             RoleId = request.RoleId,
//             AssignedAt = DateTime.UtcNow
//         };
//
//         await _userRoleRepository.AddAsync(userRole);
//
//         return "Rol asignado correctamente a un usuario";
//     }
// }


using Lab_11_Fernandez.Application.DTOs;
using Lab_11_Fernandez.Application.UseCases.UserRoles.Commands;
using Lab_11_Fernandez.Domain.Entities;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using MediatR;

public class AssignRoleHandler : IRequestHandler<AssignRoleCommand, string>
{
    private readonly IUserRoleRepository _repository;

    public AssignRoleHandler(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = new UserRole
        {
            UserId = request.Dto.UserId,
            RoleId = request.Dto.RoleId
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return "Rol asignado correctamente";
    }
}
