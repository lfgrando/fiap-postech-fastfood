using Order.Domain.Entities;

namespace Order.Application.Services.DTOs.Extensions;
internal static class OrderEntityExtensions
{
    internal static GetResponse ToResponse(this OrderEntity order)
    {
        var id = order.Id ?? string.Empty;
        var customerId = order.CustomerId ?? string.Empty;
        var customerName = order.CustomerName ?? string.Empty;

        var items = order.Items.Select(item => new OrderItemResponse(
            item.Name ?? string.Empty,
            item.Category.ToString(),
            item.Price,
            item.Amount
        ));

        var status = order.Status.ToString();
        var paymentMethod = order.PaymentMethod.ToString();
        var totalPrice = order.TotalPrice;

        return new GetResponse(id, customerId, customerName, items, status, paymentMethod, totalPrice);
    }
}
