using Kitchen.Application;
using Kitchen.Domain;
using Menu.Application;
using Menu.Domain;
using Order.Application;
using Payment.Application;
using Payment.Domain;
using SelfService.Application;
using SelfService.Domain;
using Stock.Application;
using Stock.Domain;

namespace Api.Extensions;

public static class CoreExtensions
{
    public static IServiceCollection InjectCore(this IServiceCollection services)
    {
        return services
            .InjectStockApplication()
            .InjectStockDomain()
            .InjectKitchenApplication()
            .InjectKitchenDomain()
            .InjectMenuApplication()
            .InjectMenuDomain()
            .InjectOrderApplication()
            .InjectPaymentApplication()
            .InjectPaymentDomain()
            .InjectSelfServiceApplication()
            .InjectSelfServiceDomain();
    }
}
