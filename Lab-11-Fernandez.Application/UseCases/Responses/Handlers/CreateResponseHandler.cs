using Lab_11_Fernandez.Application.UseCases.Responses.Commands;
using Lab_11_Fernandez.Domain.Entities;
using Lab_11_Fernandez.Domain.Interfaces.Repositories;

namespace Lab_11_Fernandez.Application.UseCases.Responses.Handlers;


using MediatR;


public class CreateResponseHandler : IRequestHandler<CreateResponseCommand, string>
{
    private readonly IResponseRepository _responseRepository;

    public CreateResponseHandler(IResponseRepository responseRepository)
    {
        _responseRepository = responseRepository;
    }

    public async Task<string> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
    {
        var response = new Response()
        {
            ResponseId = Guid.NewGuid(),
            TicketId = request.Dto.TicketId,
            ResponderId = request.Dto.ResponderId,
            Message = request.Dto.Message,
            CreatedAt = DateTime.UtcNow
        };

        await _responseRepository.CreateAsync(response);
        return "Respuesta registrada correctamente";
    }
}
