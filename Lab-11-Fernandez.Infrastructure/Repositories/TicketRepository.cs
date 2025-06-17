using Lab_11_Fernandez.Domain.Entities;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using Lab_11_Fernandez.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab_11_Fernandez.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<Ticket?> GetByIdAsync(Guid ticketId)
        {
            return await _context.Tickets
                .Include(t => t.Responses) // si quieres incluir relaciones
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets
                .Include(t => t.Responses)
                .ToListAsync();
        }
        public async Task DeleteAsync(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Ticket>> GetAllWithResponsesAsync()
        {
            return await _context.Tickets
                .Include(t => t.Responses)
                .ToListAsync();
        }

    }
}