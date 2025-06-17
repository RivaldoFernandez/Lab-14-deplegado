using Lab_11_Fernandez.Application.DTOs;
using Lab_11_Fernandez.Application.UseCases.Responses.Commands;
using Lab_11_Fernandez.Application.UseCases.Tickets.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab_11_Fernandez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponseController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("responder")]
    public async Task<IActionResult> CreateResponse([FromBody] ResponseDto dto)
    {
        var result = await _mediator.Send(new CreateResponseCommand(dto));
        return Ok(new { message = result });
    }
    
    



}