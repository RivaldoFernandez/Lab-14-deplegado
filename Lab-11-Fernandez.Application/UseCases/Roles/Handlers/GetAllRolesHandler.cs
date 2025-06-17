using Lab_11_Fernandez.Application.DTOs;
using Lab_11_Fernandez.Application.UseCases.Roles.Queries;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Roles.Handlers;

public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, List<RoleDto>>
{
    private readonly IRoleRepository _roleRepo;

    public GetAllRolesHandler(IRoleRepository roleRepo)
    {
        _roleRepo = roleRepo;
    }

    public async Task<List<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepo.GetAllAsync();

        return roles.Select(r => new RoleDto
        {
            RoleId = r.RoleId,
            Name = r.RoleName
        }).ToList();
    }
}