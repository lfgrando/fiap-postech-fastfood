using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Application;

public static class InventoryApplicationExtensions
{
    public static IServiceCollection InjectInventoryApplication(this IServiceCollection services)
    {
        return services;
    }
}
