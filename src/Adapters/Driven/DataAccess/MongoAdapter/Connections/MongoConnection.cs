using MongoAdapter.Interfaces;
using MongoDB.Driver;

namespace MongoAdapter.Connections;

public class MongoConnection : IMongoConnection
{
    public string? AppName { get; private set; }
    public string? ClusterName { get; private set; }
    public IMongoClient Client { get; private set; }

    public MongoConnection(string clusterName, string connectionString, string? appName = null)
    {
        AppName = appName;
        ClusterName = clusterName;
        var mongoClientSettings = MongoClientSettings.FromConnectionString(connectionString);

        if (string.IsNullOrWhiteSpace(appName))
        {
            mongoClientSettings.ApplicationName = appName;
        }

        Client = new MongoClient(mongoClientSettings);
    }
}