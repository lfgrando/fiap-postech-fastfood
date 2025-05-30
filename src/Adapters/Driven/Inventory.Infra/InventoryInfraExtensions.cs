using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Infra;

public static class InventoryInfraExtensions
{
    public static IServiceCollection InjectInventoryInfra(this IServiceCollection services)
    {
        return services;
    }
}
