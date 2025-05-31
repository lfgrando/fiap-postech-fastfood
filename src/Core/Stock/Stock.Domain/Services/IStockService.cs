using Stock.Domain.Entities;

namespace Stock.Domain.Services;

/// <summary>
/// Simulates the registering of Orders in the stock through the generation of auditable logs.
/// </summary>
public interface IStockService
{
    void RegisterOrder(
        string orderId,
        string orderStatus,
        DateTime finishDate,
        IEnumerable<ItemQuantity> itemQuantities);
}
