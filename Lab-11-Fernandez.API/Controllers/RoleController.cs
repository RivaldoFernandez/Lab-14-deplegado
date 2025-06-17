

using Lab_11_Fernandez.Application.DTOs;
using Lab_11_Fernandez.Application.UseCases.Roles.Commands;
using Lab_11_Fernandez.Application.UseCases.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab_11_Fernandez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
    {
        var roleId = await _mediator.Send(command);

        return Ok(new 
        { 
            RoleId = roleId, 
            Message = "Rol creado exitosamente" 
        });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        var result = await _mediator.Send(new DeleteRoleCommand(id));
        if (!result)
            return NotFound(new { Message = "Rol no encontrado" });

        return Ok(new { Message = "Rol eliminado exitosamente" });
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDto>>> Get()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());
        return Ok(roles);
    }

}
