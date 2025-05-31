using Microsoft.Extensions.DependencyInjection;
using Order.Application.Services;
using Order.Application.Services.Interfaces;

namespace Order.Application;

public static class OrderApplicationExtensions
{
    public static IServiceCollection InjectOrderApplication(this IServiceCollection services)
    {
        return services.AddServices();
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddSingleton<IOrderService, OrderService>();
    }
}
