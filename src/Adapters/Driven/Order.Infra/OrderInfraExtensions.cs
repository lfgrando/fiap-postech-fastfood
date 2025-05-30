using Microsoft.Extensions.DependencyInjection;

namespace Order.Infra;

public static class OrderInfraExtensions
{
    public static IServiceCollection InjectOrderInfra(this IServiceCollection services)
    {
        return services;
    }
}
