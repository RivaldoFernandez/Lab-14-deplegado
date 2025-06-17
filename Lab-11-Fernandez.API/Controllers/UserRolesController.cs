using Lab_11_Fernandez.Application.UseCases.UserRoles.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab_11_Fernandez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserRolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { message = result });
    }
}
