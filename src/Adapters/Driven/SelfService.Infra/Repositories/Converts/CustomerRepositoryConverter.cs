using SelfService.Domain.Adapters.Repositories.Interfaces;
using SelfService.Domain.Services.Entities;
using SelfService.Infra.Repositories.Entities;
using SelfService.Infra.Repositories.Interfaces;

namespace SelfService.Infra.Repositories.Converts;

public class CustomerRepositoryConverter : ICustomerRepository
{
    private readonly ICustomerMongoRepository _repository;

    public CustomerRepositoryConverter(ICustomerMongoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
    {
        var customerMongoDb = await _repository.GetByCpfAsync(cpf, cancellationToken);

        return customerMongoDb?.ToDoCustomer();
    }

    public async Task<Customer> InsertOneAsync(Customer customer, CancellationToken cancellationToken)
    {
        var customerMongoDb = CustomerMongoDb.Create(customer);

        var customerMongoDbInserted = await _repository.InsertOneAsync(customerMongoDb, cancellationToken);

        return customerMongoDbInserted.ToDoCustomer();
    }
}