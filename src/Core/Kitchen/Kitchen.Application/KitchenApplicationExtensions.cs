using Microsoft.Extensions.DependencyInjection;

namespace Kitchen.Application;

public static class KitchenApplicationExtensions
{
    public static IServiceCollection InjectKitchenApplication(this IServiceCollection services)
    {
        return services;
    }
}
