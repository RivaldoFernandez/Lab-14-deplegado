using Lab_11_Fernandez.Application.DTOs;
using MediatR;

namespace Lab_11_Fernandez.Application.UseCases.Users.Queries;

public class GetUserByIdQuery : IRequest<UserByIdDto?>
{
    public Guid UserId { get; set; }

    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
}