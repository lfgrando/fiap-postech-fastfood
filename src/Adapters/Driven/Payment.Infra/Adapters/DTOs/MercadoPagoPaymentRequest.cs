using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Payment.Infra.Adapters.DTOs;

[ExcludeFromCodeCoverage]
internal class MercadoPagoPaymentRequest
{
    [JsonPropertyName("transaction_amount")]
    public decimal TransactionAmount { get; init; }

    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; init; }

    [JsonPropertyName("metadata")]
    public MercadoPagoMetadata? Metadata { get; init; }

    [JsonPropertyName("payer")]
    public MercadoPagoPayer? Payer { get; init; }
}
