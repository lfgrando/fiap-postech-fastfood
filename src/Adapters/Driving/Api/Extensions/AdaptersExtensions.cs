using Stock.Infra;
using Kitchen.Infra;
using Menu.Infra;
using MongoAdapter;
using Order.Infra;
using Payment.Infra;
using SelfService.Infra;

namespace Api.Extensions;

public static class AdaptersExtensions
{
    public static IServiceCollection InjectDrivenAdapters(this IServiceCollection services)
    {
        return services
            .InjectMongoAdapter()
            .InjectStockInfra()
            .InjectKitchenInfra()
            .InjectMenuInfra()
            .InjectOrderInfra()
            .InjectPaymentInfra()
            .InjectSelfServiceInfra();
    }
}
