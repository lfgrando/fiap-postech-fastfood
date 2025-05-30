using SelfService.Infra.Repositories.Entities;

namespace SelfService.Infra.Repositories.Interfaces;

public interface ICustomerMongoRepository
{
    Task<CustomerMongoDb?> GetByCpfAsync(string cpf, CancellationToken cancellationToken);
    Task<CustomerMongoDb> InsertOneAsync(CustomerMongoDb customerMongoDb, CancellationToken cancellationToken);
}