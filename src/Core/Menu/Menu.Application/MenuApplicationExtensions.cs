using Menu.Application.Services;
using Menu.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Menu.Application;

public static class MenuApplicationExtensions
{
    public static IServiceCollection InjectMenuApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMenuService, MenuService>();

        return services;
    }
}
