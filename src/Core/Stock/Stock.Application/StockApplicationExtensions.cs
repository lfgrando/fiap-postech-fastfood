using Microsoft.Extensions.DependencyInjection;

namespace Stock.Application;

public static class StockApplicationExtensions
{
    public static IServiceCollection InjectStockApplication(this IServiceCollection services)
    {
        return services;
    }
}
