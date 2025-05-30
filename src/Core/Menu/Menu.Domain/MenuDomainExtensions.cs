using Microsoft.Extensions.DependencyInjection;

namespace Menu.Domain;

public static class MenuDomainExtensions
{
    public static IServiceCollection InjectMenuDomain(this IServiceCollection services)
    {
        return services;
    }
}
