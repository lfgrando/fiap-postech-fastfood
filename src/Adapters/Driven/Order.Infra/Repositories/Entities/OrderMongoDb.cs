using MongoAdapter.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Order.Domain.Entities;
using Order.Domain.Entities.Enums;


namespace Order.Infra.Repositories.Entities;

[BsonIgnoreExtraElements]
[BsonDiscriminator("order")]
public class OrderMongoDb : MongoEntity
{
    public string? CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public List<OrderItemMongoDb> Items { get; set; } = [];

    [BsonRepresentation(BsonType.String)]
    internal OrderStatus Status { get; set; }

    [BsonRepresentation(BsonType.String)]
    internal PaymentMethod PaymentMethod { get; set; }

    public decimal TotalPrice { get; set; }

    public OrderMongoDb()
    {

    }

    internal OrderMongoDb(OrderEntity order)
    {
        CustomerId = order.CustomerId;
        CustomerName = order.CustomerName;
        Items = order.Items.Select(item => new OrderItemMongoDb(item)).ToList();
        Status = order.Status;
        PaymentMethod = order.PaymentMethod;
        TotalPrice = order.TotalPrice;
    }
}
