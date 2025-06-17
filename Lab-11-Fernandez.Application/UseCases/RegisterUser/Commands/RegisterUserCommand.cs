using Lab_11_Fernandez.Application.DTOs.Auth;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.RegisterUser.Commands;

public class RegisterUserCommand : IRequest<string>
{
    public RegisterUserDto Dto { get; set; }

    public RegisterUserCommand(RegisterUserDto dto)
    {
        Dto = dto;
    }
}