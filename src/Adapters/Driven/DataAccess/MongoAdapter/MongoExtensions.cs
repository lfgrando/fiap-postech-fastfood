using Microsoft.Extensions.DependencyInjection;
using MongoAdapter.Connections;
using MongoAdapter.Factories;
using MongoAdapter.Interfaces;

namespace MongoAdapter;

public static class MongoExtensions
{
    private const string STRING_CONNECTION_MONGO = "StringConnectionMongo";

    public static IServiceCollection InjectMongoAdapter(this IServiceCollection services)
    {
        return services
            .AddConnections()
            ;
    }

    public static IServiceCollection AddConnections(this IServiceCollection services)
    {
        var stringConnectionMongo = Environment.GetEnvironmentVariable(STRING_CONNECTION_MONGO);

        services.AddSingleton<IMongoConnection>(new MongoConnection("default", stringConnectionMongo!, "FastFood.Api"));

        services.AddSingleton(DataContextFactory.Create);

        return services;
    }
}
