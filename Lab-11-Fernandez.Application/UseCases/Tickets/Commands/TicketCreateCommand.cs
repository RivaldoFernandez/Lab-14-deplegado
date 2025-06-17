using Lab_11_Fernandez.Application.DTOs;
using Lab_11_Fernandez.Application.DTOs.Ticket;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Tickets.Commands;

public record TicketCreateCommand(TicketCreateDto Dto) : IRequest<Guid>;