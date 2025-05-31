using CrossCutting.Exceptions;
using Order.Domain.Entities;

namespace Stock.Domain.Exceptions;

internal class InvalidStockOrderException(string message) : BaseEntityException<OrderEntity>(message)
{
    internal static void ThrowIfIsNotFinished(string orderStatus, string orderId)
    {
        const string FINISHED_ORDER_STATUS = "Finished";

        if (orderStatus is not FINISHED_ORDER_STATUS)
        {
            throw new InvalidStockOrderException(
                $"The order '{orderId}' should be '{FINISHED_ORDER_STATUS}' to be processed in stock.");
        }
    }
}
