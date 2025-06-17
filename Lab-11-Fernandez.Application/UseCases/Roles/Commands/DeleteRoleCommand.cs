
using MediatR;
using System;

namespace Lab_11_Fernandez.Application.UseCases.Roles.Commands
{
    public record DeleteRoleCommand(Guid RoleId) : IRequest<bool>;
}
