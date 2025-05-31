using Microsoft.Extensions.DependencyInjection;
using Stock.Domain.Adapters;
using Stock.Infra.Logger;

namespace Stock.Infra;

public static class StockInfraExtensions
{
    public static IServiceCollection InjectStockInfra(this IServiceCollection services)
    {
        services
            .AddSingleton<IStockLogger, StockLogger>();

        return services;
    }
}
