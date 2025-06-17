using Lab_11_Fernandez.Application.UseCases.Tickets.Commands;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;

namespace Lab_11_Fernandez.Application.UseCases.Tickets.Handlers;

using Lab_11_Fernandez.Domain.Interfaces;
using MediatR;


public class CloseTicketHandler : IRequestHandler<CloseTicketCommand, string>
{
    private readonly ITicketRepository _ticketRepository;

    public CloseTicketHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<string> Handle(CloseTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetByIdAsync(request.TicketId);
        if (ticket == null) return "Ticket no encontrado.";

        ticket.Status = "cerrado"; // debe coincidir con ENUM
        ticket.ClosedAt = DateTime.UtcNow;
        ticket.UpdatedAt = DateTime.UtcNow;

        await _ticketRepository.UpdateAsync(ticket);

        return "Ticket cerrado correctamente.";
    }
}
