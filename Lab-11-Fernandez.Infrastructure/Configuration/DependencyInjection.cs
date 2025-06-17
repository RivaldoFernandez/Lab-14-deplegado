using Lab_11_Fernandez.Domain.Interfaces.Repositories;
using Lab_11_Fernandez.Domain.Interfaces.Security;
using Lab_11_Fernandez.Infrastructure.Context;
using Lab_11_Fernandez.Infrastructure.Repositories;
using Lab_11_Fernandez.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lab_11_Fernandez.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        // 1. Registrar DbContext con cadena de conexión
        // 1. Registrar el ApplicationDbContext con soporte para MySQL.
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(connectionString)); // Requiere el paquete Pomelo.EntityFrameworkCore.MySql

        // 2. Registrar repositorios e interfaces
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        
        services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
        
        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        
        services.AddScoped<ITicketRepository, TicketRepository>();
        
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IResponseRepository, ResponseRepository>();



        return services;
    }
}
