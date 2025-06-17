using Lab_11_Fernandez.Application.DTOs.Ticket;

namespace Lab_11_Fernandez.Application.UseCases.Tickets.Commands;

using MediatR;

public record DeleteTicketCommand(DeleteTicketDto Dto) : IRequest<bool>;

