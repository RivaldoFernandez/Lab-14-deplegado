using Lab_11_Fernandez.Application.DTOs;
using Lab_11_Fernandez.Application.UseCases.Users.Queries;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Users.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserByIdDto?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserByIdDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null) return null;

        return new UserByIdDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}