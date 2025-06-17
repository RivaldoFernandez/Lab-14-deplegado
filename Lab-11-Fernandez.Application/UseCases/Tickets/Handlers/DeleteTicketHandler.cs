using Lab_11_Fernandez.Application.UseCases.Tickets.Commands;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;

namespace Lab_11_Fernandez.Application.UseCases.Tickets.Handlers;


using MediatR;

public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand, bool>
{
    private readonly ITicketRepository _ticketRepository;

    public DeleteTicketHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetByIdAsync(request.Dto.TicketId);
        if (ticket == null) return false;

        await _ticketRepository.DeleteAsync(ticket);
        await _ticketRepository.SaveChangesAsync();
        return true;
    }
}

