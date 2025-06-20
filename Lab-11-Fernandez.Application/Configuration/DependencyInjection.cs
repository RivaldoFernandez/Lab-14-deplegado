using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Lab_11_Fernandez.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                typeof(AssignRoleHandler).Assembly
            )
        );

        return services;
    }
}