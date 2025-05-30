using Microsoft.Extensions.DependencyInjection;

namespace Payment.Application;

public static class PaymentApplicationExtensions
{
    public static IServiceCollection InjectPaymentApplication(this IServiceCollection services)
    {
        return services;
    }
}
