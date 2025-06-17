using Lab_11_Fernandez.Domain.Entities;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using Lab_11_Fernandez.Infrastructure.Context;

namespace Lab_11_Fernandez.Infrastructure.Repositories;



public class ResponseRepository : IResponseRepository
{
    private readonly ApplicationDbContext _context;

    public ResponseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Response response)
    {
        _context.Responses.Add(response);
        await _context.SaveChangesAsync();
    }
}
