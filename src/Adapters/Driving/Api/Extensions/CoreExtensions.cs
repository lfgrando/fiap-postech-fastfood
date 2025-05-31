using Stock.Application;
using Stock.Domain;
using Kitchen.Application;
using Kitchen.Domain;
using Menu.Application;
using Menu.Domain;
using Order.Application;
using Order.Domain;
using Payment.Application;
using Payment.Domain;
using SelfService.Application;
using SelfService.Domain;

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
            .InjectOrderDomain()
            .InjectPaymentApplication()
            .InjectPaymentDomain()
            .InjectSelfServiceApplication()
            .InjectSelfServiceDomain();
    }
}
