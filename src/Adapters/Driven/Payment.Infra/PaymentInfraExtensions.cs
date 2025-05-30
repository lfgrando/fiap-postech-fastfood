using Microsoft.Extensions.DependencyInjection;

namespace Payment.Infra;

public static class PaymentInfraExtensions
{
    public static IServiceCollection InjectPaymentInfra(this IServiceCollection services)
    {
        return services;
    }
}
