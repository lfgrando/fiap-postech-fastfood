using Microsoft.Extensions.DependencyInjection;

namespace Kitchen.Domain;

public static class KitchenDomainExtensions
{
    public static IServiceCollection InjectKitchenDomain(this IServiceCollection services)
    {
        return services;
    }
}
