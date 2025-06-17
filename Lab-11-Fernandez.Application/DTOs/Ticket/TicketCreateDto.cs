namespace Lab_11_Fernandez.Application.DTOs.Ticket;

public class TicketCreateDto
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
}
