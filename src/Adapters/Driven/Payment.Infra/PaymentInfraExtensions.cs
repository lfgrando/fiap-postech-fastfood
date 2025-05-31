using Microsoft.Extensions.DependencyInjection;
using Payment.Domain.Adapters;
using Payment.Infra.Adapters;
using Polly;
using System.Net.Http.Headers;

namespace Payment.Infra;

public static class PaymentInfraExtensions
{
    public static IServiceCollection InjectPaymentInfra(this IServiceCollection services)
    {
        services.AddClients();

        return services;
    }

    public static IServiceCollection AddClients(this IServiceCollection services)
    {
        const int RETRY_COUNT = 3;

        var mercadoPagoApiUrl = Environment.GetEnvironmentVariable("MERCADOPAGO_API_URL");
        var mercadoPagoApiToken = Environment.GetEnvironmentVariable("MERCADOPAGO_API_TOKEN");

        services.AddHttpClient<IMercadoPagoPaymentAdapter, MercadoPagoClient>(client =>
        {
            client.BaseAddress = new Uri(mercadoPagoApiUrl!);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", mercadoPagoApiToken);
        }).AddTransientHttpErrorPolicy(policyBuilder =>
        {
            return policyBuilder.WaitAndRetryAsync(
                RETRY_COUNT,
                attempt => TimeSpan.FromSeconds(0.4 * Math.Pow(2, attempt)));
        });

        return services;
    }
}
