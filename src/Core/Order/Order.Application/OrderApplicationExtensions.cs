using Microsoft.Extensions.DependencyInjection;

namespace Order.Application;

public static class OrderApplicationExtensions
{
    public static IServiceCollection InjectOrderApplication(this IServiceCollection services)
    {
        return services;
    }
}
