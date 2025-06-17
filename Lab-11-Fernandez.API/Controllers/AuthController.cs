
using Lab_11_Fernandez.Application.DTOs.Auth;
using Lab_11_Fernandez.Application.UseCases.Login.Commands;
using Lab_11_Fernandez.Application.UseCases.RegisterUser.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lab_11_Fernandez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        try
        {
            var command = new RegisterUserCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(new { message = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto request)
    {
        var token = await _mediator.Send(new LoginCommand(request.Username, request.Password));
        if (token == null)
            return Unauthorized(new { message = "Invalid username or password." });

        return Ok(new { token });
    }
}