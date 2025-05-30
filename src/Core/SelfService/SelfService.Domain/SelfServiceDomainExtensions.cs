using Microsoft.Extensions.DependencyInjection;

namespace SelfService.Domain;

public static class SelfServiceDomainExtensions
{
    public static IServiceCollection InjectSelfServiceDomain(this IServiceCollection services)
    {
        return services;
    }
}