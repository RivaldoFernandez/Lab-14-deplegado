using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Login.Commands;

public class LoginCommand : IRequest<string?>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public LoginCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
