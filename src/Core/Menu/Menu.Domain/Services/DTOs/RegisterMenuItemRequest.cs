using Menu.Domain.Services.Entities;
using System.Text.Json.Serialization;

namespace Menu.Domain.Services.DTOs;

public record RegisterMenuItemRequest(
    string? Name,
    decimal Price,
    MenuCategory Category,
    string? Description)
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MenuCategory Category { get; init; } = Category;
}