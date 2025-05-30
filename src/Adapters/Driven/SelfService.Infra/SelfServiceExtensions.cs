using Microsoft.Extensions.DependencyInjection;
using SelfService.Domain.Adapters.Repositories.Interfaces;
using SelfService.Infra.Repositories;
using SelfService.Infra.Repositories.Converts;
using SelfService.Infra.Repositories.Interfaces;

namespace SelfService.Infra;

public static class SelfServiceExtensions
{
    public static IServiceCollection InjectSelfServiceInfra(this IServiceCollection services)
    {
        return services
            .AddRepositories()
            ;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerMongoRepository, CustomerMongoRepository>();

        services.AddSingleton<ICustomerRepository, CustomerRepositoryConverter>();

        return services;
    }
}
