using Lab_11_Fernandez.Application.DTOs;
using MediatR;
using System.Collections.Generic;
namespace Lab_11_Fernandez.Application.UseCases.Users.Queries;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
}