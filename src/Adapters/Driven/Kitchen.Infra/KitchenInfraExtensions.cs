using Microsoft.Extensions.DependencyInjection;

namespace Kitchen.Infra;

public static class KitchenInfraExtensions
{
    public static IServiceCollection InjectKitchenInfra(this IServiceCollection services)
    {
        return services;
    }
}
