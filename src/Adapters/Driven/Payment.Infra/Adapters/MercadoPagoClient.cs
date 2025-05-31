using Microsoft.Extensions.Logging;
using Order.Domain.Entities.Enums;
using Payment.Domain.Adapters;
using Payment.Domain.Adapters.DTOs;
using Payment.Domain.Entities;
using Payment.Infra.Adapters.DTOs;
using Payment.Infra.Adapters.DTOs.Extensions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Payment.Infra.Adapters;

public class MercadoPagoClient : IMercadoPagoPaymentAdapter
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<MercadoPagoClient> _logger;

    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public MercadoPagoClient(HttpClient httpClient, ILogger<MercadoPagoClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<OrderPaymentCheckoutEntity> CreatePaymentAsync(
        CheckoutInput input,
        PaymentMethod paymentMethod,
        CancellationToken cancellationToken)
    {
        const string CREATE_PAYMENT_PATH_TEMPLATE = "/v1/payments";
        const string IDEMPOTENCY_KEY = "X-Idempotency-Key";

        var request = new HttpRequestMessage(HttpMethod.Post, CREATE_PAYMENT_PATH_TEMPLATE)
        {
            Headers = { { IDEMPOTENCY_KEY, input.OrderId } },
            Content = CreateContent(input, paymentMethod)
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

        if (response.IsSuccessStatusCode is false)
        {
            _logger.LogCritical(
                "Failed to create payment for order {OrderId}. Response: {ResponseContent}",
                input.OrderId,
                responseContent);

            throw new HttpRequestException($"Failed to create payment for order {input.OrderId}. Status code: {response.StatusCode}");
        }

        var mercadoPagoResponse = JsonSerializer.Deserialize<MercadoPagoPaymentResponse>(responseContent, _jsonSerializerOptions);

        return mercadoPagoResponse!.ToOrderPaymentCheckoutEntity();

    }

    private static StringContent CreateContent(CheckoutInput input, PaymentMethod paymentMethod)
    {
        const string CONTENT_TYPE = "application/json";

        var requestContent = new MercadoPagoPaymentRequest
        {
            TransactionAmount = input.TotalPrice,
            PaymentMethodId = paymentMethod.ToString().ToLower(),
            Metadata = new MercadoPagoMetadata
            {
                OrderNumber = input.OrderId
            },
            Payer = new MercadoPagoPayer
            {
                FirstName = input.CustomerName!.Split(' ').FirstOrDefault(),
                LastName = input.CustomerName!.Split(' ').LastOrDefault(),
                Email = input.CustomerEmail
            }
        };

        return new StringContent(
            JsonSerializer.Serialize(requestContent),
            Encoding.UTF8,
            CONTENT_TYPE);
    }
}
