using Microsoft.Extensions.Logging;
using Stock.Domain.Adapters;
using System.Diagnostics.CodeAnalysis;

namespace Stock.Infra.Logger;

[ExcludeFromCodeCoverage]
internal class StockLogger : IStockLogger
{
    private readonly ILogger<StockLogger> _logger;

    public StockLogger(ILogger<StockLogger> logger)
    {
        _logger = logger;
    }

    public void SendAuditLog(string auditLog)
    {
        _logger.LogInformation("{AuditLog}", auditLog);
    }
}
