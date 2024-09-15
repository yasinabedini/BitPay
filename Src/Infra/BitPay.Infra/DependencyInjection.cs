using BitPay.Domain;
using BitPay.Domain.Member.Repositories;
using BitPay.Domain.Merchant.Repositories;
using BitPay.Domain.Payment.Repositories;
using BitPay.Domain.Transfer.Repositories;
using BitPay.Infra.Context;
using BitPay.Infra.Models.Member.Repositories;
using BitPay.Infra.Models.Merchant.Repositories;
using BitPay.Infra.Models.Payment.Repositories;
using BitPay.Infra.Models.Transfer.Repositories;
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

        services.AddDbContext<BitPayDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("LOCAL_DB")));

        services.AddTransient<IMemberRepository, MemberRepository>();
        services.AddTransient<IMerchantRepository, MerchantRepository>();
        services.AddTransient<IPaymentRepository, PaymentRepository>();
        services.AddTransient<ITransferRepository, TransferRepository>();

        return services;
    }
}
