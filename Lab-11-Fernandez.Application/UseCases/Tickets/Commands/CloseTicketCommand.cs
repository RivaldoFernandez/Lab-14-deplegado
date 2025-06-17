using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Tickets.Commands
{
    public class CloseTicketCommand : IRequest<string>
    {
        public Guid TicketId { get; }

        public CloseTicketCommand(Guid ticketId)
        {
            TicketId = ticketId;
        }
    }
}