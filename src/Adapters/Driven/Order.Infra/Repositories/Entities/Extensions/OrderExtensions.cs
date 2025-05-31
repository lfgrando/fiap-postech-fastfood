using Order.Domain.Entities;
using OrderEntity = Order.Domain.Entities.OrderEntity;

namespace Order.Infra.Repositories.Entities.Extensions;
internal static class OrderExtensions
{
    internal static OrderEntity ToDomain(this OrderMongoDb orderMongoDb)
    {
        return new OrderEntity(
            orderMongoDb.Id,
            orderMongoDb.CustomerId,
            orderMongoDb.CustomerName,
            orderMongoDb.Items.Select(item => new OrderItem(item.Id, item.Name, item.Category, item.Price, item.Amount)),
            orderMongoDb.Status,
            orderMongoDb.PaymentMethod,
            orderMongoDb.TotalPrice);
    }
}