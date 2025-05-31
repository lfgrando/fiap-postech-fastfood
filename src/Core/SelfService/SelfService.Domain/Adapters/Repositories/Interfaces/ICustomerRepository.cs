using SelfService.Domain.Services.Entities;

namespace SelfService.Domain.Adapters.Repositories.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetByCpfAsync(string cpf, CancellationToken cancellationToken);
    Task<Customer?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<Customer> InsertOneAsync(Customer customer, CancellationToken cancellationToken);
}