using Lab_11_Fernandez.Application.UseCases.Tickets.Commands;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Tickets.Handlers;

public class AssignTicketHandler : IRequestHandler<AssignTicketCommand, bool>
{
    private readonly ITicketRepository _ticketRepo;
    private readonly IUserRepository _userRepo; // Para validar que el técnico existe

    public AssignTicketHandler(ITicketRepository ticketRepo, IUserRepository userRepo)
    {
        _ticketRepo = ticketRepo;
        _userRepo = userRepo;
    }

    public async Task<bool> Handle(AssignTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepo.GetByIdAsync(request.TicketId);
        if (ticket == null)
        {
            Console.WriteLine("❌ Ticket no encontrado");
            return false;
        }

        if (ticket.Status != "abierto")
        {
            Console.WriteLine($"❌ Ticket no está abierto, estado actual: {ticket.Status}");
            return false;
        }

        var technician = await _userRepo.GetByIdAsync(request.TechnicianId);
        if (technician == null)
        {
            Console.WriteLine("❌ Técnico no encontrado");
            return false;
        }

        ticket.UserId = request.TechnicianId;
        ticket.Status = "en_proceso";
        ticket.UpdatedAt = DateTime.UtcNow;

        await _ticketRepo.UpdateAsync(ticket);
        await _ticketRepo.SaveChangesAsync();

        Console.WriteLine("✅ Ticket asignado correctamente");
        return true;
    }

}
