using Lab_11_Fernandez.Application.UseCases.Login.Commands;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using Lab_11_Fernandez.Domain.Interfaces.Security;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Login.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, string?>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null) return null;

        var valid = _passwordHasher.VerifyPassword(user.PasswordHash, request.Password);
        if (!valid) return null;

        return _tokenGenerator.GenerateToken(user);
    }
}
