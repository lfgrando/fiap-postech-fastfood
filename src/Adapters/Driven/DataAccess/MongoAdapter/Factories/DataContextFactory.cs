using Microsoft.Extensions.DependencyInjection;
using MongoAdapter.Contexts;
using MongoAdapter.Contexts.Interfaces;
using MongoAdapter.Interfaces;

namespace MongoAdapter.Factories;

public static class DataContextFactory
{
    public static IMongoContext Create(IServiceProvider serviceProvider)
    {
        var mongoConnections = serviceProvider.GetServices<IMongoConnection>();

        var mongoConnection = mongoConnections.Where(w => w.ClusterName == "default").FirstOrDefault();

        var mongoDatabase = mongoConnection!.Client.GetDatabase("fastfood");

        return new MongoContext("default", mongoDatabase);
    }
}
