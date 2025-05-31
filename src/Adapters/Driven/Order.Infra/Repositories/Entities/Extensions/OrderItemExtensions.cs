using Order.Domain.Entities;

namespace Order.Infra.Repositories.Entities.Extensions;
internal static class OrderItemExtensions
{
    internal static OrderItem ToDomain(this OrderItemMongoDb orderItemMongoDb)
    {
        return new OrderItem
        (
            orderItemMongoDb.Id,
            orderItemMongoDb.Name,
            orderItemMongoDb.Category,
            orderItemMongoDb.Price,
            orderItemMongoDb.Amount
        );
    }
}
