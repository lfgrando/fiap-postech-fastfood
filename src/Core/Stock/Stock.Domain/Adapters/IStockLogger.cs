namespace Stock.Domain.Adapters;

public interface IStockLogger
{
    void SendAuditLog(string auditLog);
}
