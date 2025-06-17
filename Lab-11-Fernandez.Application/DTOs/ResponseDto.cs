namespace Lab_11_Fernandez.Application.DTOs;

public class ResponseDto
{
    public Guid TicketId { get; set; }
    public Guid ResponderId { get; set; }
    public string Message { get; set; } = null!;
}