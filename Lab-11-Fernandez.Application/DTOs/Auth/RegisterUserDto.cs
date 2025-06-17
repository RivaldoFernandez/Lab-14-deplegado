namespace Lab_11_Fernandez.Application.DTOs.Auth;

public class RegisterUserDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Email { get; set; }
}