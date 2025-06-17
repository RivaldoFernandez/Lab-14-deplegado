

using Lab_11_Fernandez.Domain.Entities;

namespace Lab_11_Fernandez.Domain.Interfaces.Repositories;

public interface IResponseRepository
{
    Task CreateAsync(Response response);
}
