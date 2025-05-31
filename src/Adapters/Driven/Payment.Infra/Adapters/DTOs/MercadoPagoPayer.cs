using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Payment.Infra.Adapters.DTOs;

[ExcludeFromCodeCoverage]
internal class MercadoPagoPayer
{
    [JsonPropertyName("first_name")]
    public string? FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }
}
