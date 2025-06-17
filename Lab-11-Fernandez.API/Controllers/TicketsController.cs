using Lab_11_Fernandez.Application.DTOs.Ticket;

namespace Lab_11_Fernandez.Controllers;

using Lab_11_Fernandez.Application.UseCases.Tickets.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] TicketCreateCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { TicketId = id, message = "Ticket creado exitosamente" });
    }
    [HttpPost("cerrar/{ticketId}")]
    public async Task<IActionResult> CerrarTicket(Guid ticketId)
    {
        var result = await _mediator.Send(new CloseTicketCommand(ticketId));
        return Ok(new { message = result });
    }
    
    // Cambia esta acción para que reciba el technicianId como parámetro de query
    [HttpPost("asignar/{ticketId}")]
    public async Task<IActionResult> AssignTicket(Guid ticketId, [FromQuery] Guid technicianId)
    {
        var command = new AssignTicketCommand
        {
            TicketId = ticketId,
            TechnicianId = technicianId
        };

        var result = await _mediator.Send(command);

        if (!result)
            return BadRequest("No se pudo asignar el ticket");

        return Ok("Ticket asignado correctamente");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteTicket([FromBody] DeleteTicketDto dto)
    {
        var command = new DeleteTicketCommand(dto); // ✅ Correcto
        var result = await _mediator.Send(command);

        if (!result)
            return NotFound("No se encontró el ticket a eliminar");

        return Ok("Ticket eliminado correctamente");
    }
    
}
