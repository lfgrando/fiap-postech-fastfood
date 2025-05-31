using MongoAdapter.Entities;
using Order.Domain.Entities;
using Order.Domain.Entities.Enums;
using Order.Infra.Repositories.Entities;

namespace Order.Infra.Repositories.Interfaces;
internal interface IOrderMongoDbRepository
{
    Task<string> CreateAsync(OrderMongoDb order, CancellationToken cancellationToken);
    Task<OrderMongoDb?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<PagedResult<OrderMongoDb>> GetAllByStatus(OrderStatus status, int page, int size, CancellationToken cancellationToken);
    Task<PagedResult<OrderMongoDb>> GetAllPaginate(int page, int size, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task UpdatePaymentMethodAsync(
        string id,
        PaymentMethod paymentMethod,
        CancellationToken cancellationToken);
    Task<OrderMongoDb> UpdateStatusAsync(
        string id,
        OrderStatus status,
        CancellationToken cancellationToken);
}
