using Lab_11_Fernandez.Application.UseCases.Roles.Commands;
using Lab_11_Fernandez.Domain.Entities;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Roles.Handlers;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            RoleId = Guid.NewGuid(),
            RoleName = request.RoleName,
            CreatedAt = DateTime.UtcNow
        };

        await _roleRepository.AddAsync(role);
        return role.RoleId;
    }
}