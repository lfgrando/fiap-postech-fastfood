using SelfService.Domain.Adapters.Repositories.Interfaces;
using SelfService.Domain.Services.DTOs;
using SelfService.Domain.Services.Entities;
using SelfService.Domain.Services.Interfaces;

namespace SelfService.Application.Services;

public class RegisterCustomerManager : IRegisterCustomerService
{
    private readonly ICustomerRepository _repository;

    public RegisterCustomerManager(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerResponse> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            throw new ArgumentNullException(nameof(cpf));
        }

        var customer = await _repository.GetByCpfAsync(cpf, cancellationToken);

        if (customer is null)
        {
            throw new ApplicationException("customer does not exist");
        }

        var response = new CustomerResponse(customer.Id!, customer.Email ?? string.Empty);

        return response;
    }

    public async Task<CustomerResponse> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var customer = await _repository.GetByIdAsync(id, cancellationToken);

        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        var response = new CustomerResponse(customer.Id!, customer.Email ?? string.Empty);

        return response;
    }

    public async Task<CustomerResponse> RegisterAsync(RegisterCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.CPF, request.Name, request.Email);

        customer = await _repository.InsertOneAsync(customer, cancellationToken);

        var response = new CustomerResponse(customer.Id!, customer.Email ?? string.Empty);

        return response;
    }
}
