using Order.Domain.Entities;
using Order.Domain.Entities.Enums;
using OrderEntity = Order.Domain.Entities.OrderEntity;

namespace Order.Domain.Repositories.Interfaces;
internal interface IOrderRepository
{
    Task<string> CreateAsync(OrderEntity order, CancellationToken cancellationToken);
    Task<OrderEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<Pagination<OrderEntity>> GetAllByStatus(OrderStatus status, int page, int size, CancellationToken cancellationToken);
    Task<Pagination<OrderEntity>> GetAllPaginate(int page, int size, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<OrderEntity> UpdateStatusAsync(
        string id,
        OrderStatus status,
        CancellationToken cancellationToken);
}
