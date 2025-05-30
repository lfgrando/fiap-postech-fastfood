using Menu.Domain.Services.Entities;
using MongoAdapter.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Menu.Infra.Repositories.Entities;

[BsonIgnoreExtraElements]
[BsonDiscriminator("menu")]
public class MenuItemMongoDb : MongoEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public MenuCategory Category { get; set; }

    public static MenuItemMongoDb Create(MenuItem menuItem)
    {
        return new MenuItemMongoDb()
        {
            Name = menuItem.Name,
            Description = menuItem.Description,
            Price = menuItem.Price,
            IsActive = menuItem.IsActive,
            Category = menuItem.Category
        };
    }

    public MenuItem ToDomain()
    {
        return new MenuItem(Name!, Price, Category, Description!, IsActive)
        {
            Id = Id,
            Created = Created,
        };
    }
}