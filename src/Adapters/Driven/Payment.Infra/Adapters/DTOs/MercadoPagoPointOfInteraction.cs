using System.Text.Json.Serialization;

namespace Payment.Infra.Adapters.DTOs;

internal class MercadoPagoPointOfInteraction
{
    [JsonPropertyName("transaction_data")]
    public MercadoPagoTransactionData? TransactionData { get; init; }
}
