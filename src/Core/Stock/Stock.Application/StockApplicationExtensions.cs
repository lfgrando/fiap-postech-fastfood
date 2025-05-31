using Microsoft.Extensions.DependencyInjection;
using Stock.Application.Services;
using Stock.Domain.Services;

namespace Stock.Application;

public static class StockApplicationExtensions
{
    public static IServiceCollection InjectStockApplication(this IServiceCollection services)
    {
        services
            .AddSingleton<IStockService, StockService>();

        return services;
    }
}
