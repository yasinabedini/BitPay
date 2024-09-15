using BitPay.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace BitPay.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddInfrastructure();

        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(configuration =>
              configuration.RegisterServicesFromAssemblies(assembly));


        return services;
    }
}
