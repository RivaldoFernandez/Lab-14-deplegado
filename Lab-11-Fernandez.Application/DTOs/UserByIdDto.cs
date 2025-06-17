namespace Lab_11_Fernandez.Application.DTOs;

public class UserByIdDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}