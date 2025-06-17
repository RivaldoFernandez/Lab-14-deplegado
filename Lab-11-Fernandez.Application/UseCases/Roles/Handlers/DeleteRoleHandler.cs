
using Lab_11_Fernandez.Application.UseCases.Roles.Commands;

namespace Lab_11_Fernandez.Application.UseCases.Roles.Handlers;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.RoleId);
        if (role == null) return false;

        await _roleRepository.DeleteAsync(role);
        return true;
    }
}

