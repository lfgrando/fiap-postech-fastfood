using Microsoft.Extensions.DependencyInjection;

namespace Stock.Domain;

public static class StockDomainExtensions
{
    public static IServiceCollection InjectStockDomain(this IServiceCollection services)
    {
        return services;
    }
}
