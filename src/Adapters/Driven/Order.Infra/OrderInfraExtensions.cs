using Microsoft.Extensions.DependencyInjection;
using Order.Domain.Repositories.Interfaces;
using Order.Infra.Adapters;
using Order.Infra.Repositories;
using Order.Infra.Repositories.Interfaces;

namespace Order.Infra;

public static class OrderInfraExtensions
{
    public static IServiceCollection InjectOrderInfra(this IServiceCollection services)
    {
        return services
            .AddRepositories();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddSingleton<IOrderRepository, OrderRepository>()
            .AddSingleton<IOrderMongoDbRepository, OrderMongoDbRepository>(); ;
    }
}
