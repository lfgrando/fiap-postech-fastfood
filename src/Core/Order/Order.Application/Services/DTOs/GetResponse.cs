namespace Order.Application.Services.DTOs;

public record GetResponse
(
    string Id,
    string CustomerId,
    string CustomerName,
    IEnumerable<OrderItemResponse> Items,
    string Status,
    string PaymentMethod,
    decimal TotalPrice
)
{ }
