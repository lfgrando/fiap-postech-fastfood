using Microsoft.Extensions.DependencyInjection;

namespace Payment.Domain;

public static class PaymentDomainExtensions
{
    public static IServiceCollection InjectPaymentDomain(this IServiceCollection services)
    {
        return services;
    }
}
