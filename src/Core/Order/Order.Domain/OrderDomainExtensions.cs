using Microsoft.Extensions.DependencyInjection;

namespace Order.Domain;

public static class OrderDomainExtensions
{
    public static IServiceCollection InjectOrderDomain(this IServiceCollection services)
    {
        return services;
    }
}