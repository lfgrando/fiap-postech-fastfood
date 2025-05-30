using SelfService.Domain.Services.Entities.Exceptions;

namespace SelfService.Domain.Services.Entities;

public class Customer
{
    private string? _CPF;
    private string? _Name;
    private string? _Email;

    public DateTime Created { get; set; }
    public string? Id { get; set; } = string.Empty;

    public string? CPF { get => _CPF; set => _CPF = CustomerException.ThrowIfEmptyOrWhiteSpace(value, nameof(CPF)); }
    public string? Name { get => _Name; set => _Name = CustomerException.ThrowIfEmptyOrWhiteSpace(value, nameof(Name)); }
    public string? Email { get => _Email; set => _Email = CustomerException.ThrowIfEmptyOrWhiteSpace(value, nameof(Email)); }


    public Customer(string? cpf, string? name, string? email)
    {
        CPF = cpf;
        Name = name;
        Email = email;
    }
}