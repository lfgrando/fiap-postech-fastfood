using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Order.Domain.Entities;
using Order.Domain.Entities.Enums;

namespace Order.Infra.Repositories.Entities;

[BsonIgnoreExtraElements]
public class OrderItemMongoDb
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }

    [BsonRepresentation(BsonType.String)]
    internal ItemCategory Category { get; set; }

    public OrderItemMongoDb()
    {

    }

    internal OrderItemMongoDb(OrderItem orderItem)
    {
        Id = orderItem.Id;
        Name = orderItem.Name;
        Price = orderItem.Price;
        Amount = orderItem.Amount;
        Category = orderItem.Category;
    }
}
