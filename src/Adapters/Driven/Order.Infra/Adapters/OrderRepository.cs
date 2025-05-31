using Order.Domain.Entities;
using Order.Domain.Entities.Enums;
using Order.Domain.Repositories.Interfaces;
using Order.Infra.Repositories.Entities;
using Order.Infra.Repositories.Entities.Extensions;
using Order.Infra.Repositories.Interfaces;

namespace Order.Infra.Adapters;
internal class OrderRepository : IOrderRepository
{
    private readonly IOrderMongoDbRepository _orderMongoDbRepository;

    public OrderRepository(IOrderMongoDbRepository orderMongoDbRepository)
    {
        _orderMongoDbRepository = orderMongoDbRepository;
    }

    public Task<string> CreateAsync(OrderEntity order, CancellationToken cancellationToken)
    {
        var orderMongoDb = new OrderMongoDb(order);
        return _orderMongoDbRepository.CreateAsync(orderMongoDb, cancellationToken);
    }

    public Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        return _orderMongoDbRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<Pagination<OrderEntity>> GetAllByStatus(OrderStatus status, int page, int size, CancellationToken cancellationToken)
    {
        var pagedResult = await _orderMongoDbRepository.GetAllByStatus(status, page, size, cancellationToken);

        var pagedDomain = pagedResult.ToDomain();
        return pagedDomain;
    }

    public async Task<Pagination<OrderEntity>> GetAllPaginate(int page, int size, CancellationToken cancellationToken)
    {
        var pagedResult = await _orderMongoDbRepository.GetAllPaginate(page, size, cancellationToken);

        var pagedDomain = pagedResult.ToDomain();
        return pagedDomain;
    }

    public async Task<OrderEntity?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var orderMongoDB = await _orderMongoDbRepository.GetByIdAsync(id, cancellationToken);
        return orderMongoDB?.ToDomain();
    }

    public async Task<OrderEntity> UpdateStatusAsync(string id, OrderStatus status, CancellationToken cancellationToken)
    {
        var orderMongoDb = await _orderMongoDbRepository.UpdateStatusAsync(id, status, cancellationToken);
        return orderMongoDb.ToDomain();
    }
}
