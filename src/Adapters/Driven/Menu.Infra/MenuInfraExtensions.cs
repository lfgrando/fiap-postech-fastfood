using Menu.Domain.Adapters.Repositories.Interfaces;
using Menu.Infra.Repositories;
using Menu.Infra.Repositories.Converts;
using Menu.Infra.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Menu.Infra;

public static class MenuInfraExtensions
{
    public static IServiceCollection InjectMenuInfra(this IServiceCollection services)
    {
        return services
            .AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IMenuMongoRepository, MenuMongoRepository>();

        services.AddSingleton<IMenuRepository, MenuRepositoryConverter>();

        return services;
    }
}
