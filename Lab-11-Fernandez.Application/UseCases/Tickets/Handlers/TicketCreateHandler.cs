using Lab_11_Fernandez.Application.UseCases.Tickets.Commands;
using Lab_11_Fernandez.Domain.Entities;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Tickets.Handlers;

public class TicketCreateHandler : IRequestHandler<TicketCreateCommand, Guid>
{
    private readonly ITicketRepository _repository;

    public TicketCreateHandler(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(TicketCreateCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket()
        {
            TicketId = Guid.NewGuid(),
            UserId = request.Dto.UserId,
            Title = request.Dto.Title,
            Description = request.Dto.Description,
            Status = "Abierto",
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(ticket);
        // Asegúrate de guardar cambios si es necesario, ejemplo:
        // await _repository.SaveChangesAsync();

        return ticket.TicketId;
    }
}