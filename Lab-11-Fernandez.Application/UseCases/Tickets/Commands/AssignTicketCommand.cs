using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Tickets.Commands;
public class AssignTicketCommand : IRequest<bool>
{
    public Guid TicketId { get; set; }
    public Guid TechnicianId { get; set; }
}
