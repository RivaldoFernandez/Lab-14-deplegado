using Lab_11_Fernandez.Application.DTOs;

namespace Lab_11_Fernandez.Application.UseCases.UserRoles.Commands;

using MediatR;



public record AssignRoleCommand(UserRoleDto Dto) : IRequest<string>;