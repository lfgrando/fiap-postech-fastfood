using System.Text.Json.Serialization;

namespace Payment.Infra.Adapters.DTOs;

internal class MercadoPagoTransactionData
{
    [JsonPropertyName("qr_code")]
    public string? QrCode { get; init; }

    [JsonPropertyName("qr_code_base64")]
    public string? QrCodeBase64 { get; init; }
}
