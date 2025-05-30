using MongoAdapter.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAdapter.Entities;

[Serializable]
public class MongoEntity : IMongoEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public DateTime Created { get; set; }

    public MongoEntity()
    {
        Created = DateTime.UtcNow;
    }
}