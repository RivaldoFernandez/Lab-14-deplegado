using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Roles.Commands;

public class CreateRoleCommand : IRequest<Guid>
{
    public string RoleName { get; set; } = null!;
}