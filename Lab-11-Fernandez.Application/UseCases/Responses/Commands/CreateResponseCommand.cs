using Lab_11_Fernandez.Application.DTOs;

namespace Lab_11_Fernandez.Application.UseCases.Responses.Commands;

using MediatR;


public record CreateResponseCommand(ResponseDto Dto) : IRequest<string>;
