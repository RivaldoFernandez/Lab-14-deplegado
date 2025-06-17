
using Lab_11_Fernandez.Application.UseCases.RegisterUser.Commands;
using Lab_11_Fernandez.Domain.Entities;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using Lab_11_Fernandez.Domain.Interfaces.Security;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.RegisterUser.Handlers;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.UserExistsAsync(request.Dto.Username))
        {
            throw new Exception("Username already exists");
        }

        var hashedPassword = _passwordHasher.HashPassword(request.Dto.Password);

        var user = new User()
        {
            UserId = Guid.NewGuid(),
            Username = request.Dto.Username,
            PasswordHash = hashedPassword,
            Email = request.Dto.Email
        };

        await _userRepository.AddUserAsync(user);

        return "User registered successfully";
    }
}