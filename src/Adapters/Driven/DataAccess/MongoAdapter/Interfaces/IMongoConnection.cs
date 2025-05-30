using MongoDB.Driver;

namespace MongoAdapter.Interfaces;

public interface IMongoConnection
{
    public string? AppName { get; }
    public string? ClusterName { get; }
    public IMongoClient Client { get; }
}