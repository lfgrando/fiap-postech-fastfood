namespace Payment.Domain.Adapters.DTOs;
public record CheckoutInput
(
    string CustomerId,
    string CustomerName,
    string CustomerEmail,
    string OrderId,
    decimal TotalPrice
)
{ }
