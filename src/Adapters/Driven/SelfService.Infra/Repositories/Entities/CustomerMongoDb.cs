using MongoAdapter.Entities;
using MongoDB.Bson.Serialization.Attributes;
using SelfService.Domain.Services.Entities;

namespace SelfService.Infra.Repositories.Entities;

[BsonIgnoreExtraElements]
[BsonDiscriminator("customer")]
public class CustomerMongoDb : MongoEntity
{
    public string? CPF { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public static CustomerMongoDb Create(Customer customer)
    {
        return new CustomerMongoDb()
        {
            CPF = customer.CPF,
            Name = customer.Name,
            Email = customer.Email,
        };
    }

    public Customer ToDoCustomer()
    {
        return new Customer(CPF, Name, Email)
        {
            Id = Id,
            Created = Created,
        };
    }
}