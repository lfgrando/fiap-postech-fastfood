using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Domain;

public static class InventoryDomainExtensions
{
    public static IServiceCollection InjectInventoryDomain(this IServiceCollection services)
    {
        return services;
    }
}
