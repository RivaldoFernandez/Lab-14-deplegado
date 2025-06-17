using Lab_11_Fernandez.Application.DTOs;
using Lab_11_Fernandez.Application.UseCases.Users.Queries;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;

namespace Lab_11_Fernandez.Application.UseCases.Users.Handlers;
using MediatR;
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(user => new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        }).ToList();
    }
}