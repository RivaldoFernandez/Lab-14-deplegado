using Lab_11_Fernandez.Domain.Entities;

namespace Lab_11_Fernandez.Domain.Interfaces.Repositories;
public interface ITicketRepository
{
    Task AddAsync(Ticket ticket);
    Task<Ticket?> GetByIdAsync(Guid ticketId);
    Task UpdateAsync(Ticket ticket);
    Task SaveChangesAsync();
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task DeleteAsync(Ticket ticket);
    Task<IEnumerable<Ticket>> GetAllWithResponsesAsync(); // incluye respuestas (con Include)


}
