namespace Order.Infra.Repositories.Entities.Extensions;

using MongoAdapter.Entities;
using Order.Domain.Entities;
using OrderEntity = Order.Domain.Entities.OrderEntity;
internal static class PaginationExtension
{
    internal static Pagination<OrderEntity> ToDomain(this PagedResult<OrderMongoDb> pagination)
    {
        return new Pagination<OrderEntity>()
        {
            Page = pagination.Page,
            Size = pagination.Size,
            TotalPages = pagination.TotalPages,
            TotalCount = pagination.TotalCount,
            Items = pagination.Items.Select(item => item.ToDomain())
        };
    }
}
