using BitPay.Domain;
using BitPay.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitPay.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDomain();

        IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.AddDomain();

        services.AddDbContext<BitPayDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("LOCAL_DB")));

        return services;
    }
}
