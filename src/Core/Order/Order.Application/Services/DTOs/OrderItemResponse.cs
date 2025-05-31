namespace Order.Application.Services.DTOs;

public record OrderItemResponse
(
    string? Name,
    string? Category,
    decimal Price,
    int Amout
)
{ }