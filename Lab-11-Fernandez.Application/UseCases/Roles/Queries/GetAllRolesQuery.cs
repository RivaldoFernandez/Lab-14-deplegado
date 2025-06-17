
using MediatR;
using System.Collections.Generic;
using Lab_11_Fernandez.Application.DTOs;

namespace Lab_11_Fernandez.Application.UseCases.Roles.Queries;

public record GetAllRolesQuery : IRequest<List<RoleDto>>;