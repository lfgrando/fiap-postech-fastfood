using MongoDB.Driver;

namespace MongoAdapter.Contexts.Interfaces;

public interface IMongoContext
{
    public string ClusterName { get; }
    public IMongoDatabase Database { get; }

    IMongoCollection<TEntity> GetCollection<TEntity>();
}