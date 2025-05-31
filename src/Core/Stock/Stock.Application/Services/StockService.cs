using Stock.Domain.Adapters;
using Stock.Domain.Entities;
using Stock.Domain.Exceptions;
using Stock.Domain.Services;
using System.Text;

namespace Stock.Application.Services;

internal class StockService : IStockService
{
    private readonly IStockLogger _logger;

    public StockService(IStockLogger logger)
    {
        _logger = logger;
    }

    public void RegisterOrder(
        string orderId,
        string orderStatus,
        DateTime finishDate,
        IEnumerable<ItemQuantity> itemQuantities)
    {
        InvalidStockOrderException.ThrowIfIsNotFinished(orderStatus, orderId!);

        var auditLogBuilder = new StringBuilder();

        const string AUDIT_LOG_TEMPLATE = "The order {0} was finished in {1} with: {2}";

        foreach (var itemQuantity in itemQuantities)
        {
            var auditLog = string.Format(
                AUDIT_LOG_TEMPLATE,
                orderId,
                finishDate.ToString("yyyy-MM-dd HH:mm:ss"),
                itemQuantity.ToString());

            auditLogBuilder.AppendLine(auditLog);
        }

        _logger.SendAuditLog(auditLogBuilder.ToString());
    }
}
