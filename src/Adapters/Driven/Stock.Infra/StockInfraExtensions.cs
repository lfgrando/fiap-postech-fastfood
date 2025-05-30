using Microsoft.Extensions.DependencyInjection;

namespace Stock.Infra;

public static class StockInfraExtensions
{
    public static IServiceCollection InjectStockInfra(this IServiceCollection services)
    {
        return services;
    }
}
