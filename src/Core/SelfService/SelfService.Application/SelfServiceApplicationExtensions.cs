using Microsoft.Extensions.DependencyInjection;
using SelfService.Application.Services;
using SelfService.Domain.Services.Interfaces;

namespace SelfService.Application;

public static class SelfServiceApplicationExtensions
{
    public static IServiceCollection InjectSelfServiceApplication(this IServiceCollection services)
    {
        services.AddSingleton<IRegisterCustomerService, RegisterCustomerManager>();

        return services;
    }
}