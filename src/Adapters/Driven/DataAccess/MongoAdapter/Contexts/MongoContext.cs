using MongoAdapter.Contexts.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoAdapter.Contexts;

public class MongoContext : IMongoContext
{
    public string ClusterName { get; }

    public IMongoDatabase Database { get; }

    public MongoContext(string clusterName, IMongoDatabase mongoDatabase)
    {
        Database = mongoDatabase;
        ClusterName = clusterName;
    }

    public string GetCollectionName<TEntity>()
    {
        if (Attribute.GetCustomAttribute(typeof(TEntity), typeof(BsonDiscriminatorAttribute)) != null)
        {
            BsonClassMap bsonClassMap = BsonClassMap.LookupClassMap(typeof(TEntity));
            if (!string.IsNullOrWhiteSpace(bsonClassMap.Discriminator))
            {
                return bsonClassMap.Discriminator;
            }

        }

        string text = typeof(TEntity).Name;
        text = char.ToLower(text[0]) + text.Substring(1);

        return text;
    }

    public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName)
    {
        return Database.GetCollection<TEntity>(collectionName);
    }

    public IMongoCollection<TEntity> GetCollection<TEntity>()
    {
        var collectionName = GetCollectionName<TEntity>();

        return GetCollection<TEntity>(collectionName);
    }
}