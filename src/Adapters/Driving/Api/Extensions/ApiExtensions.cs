using Api.Filters;

namespace Api.Extensions;

public static class ApiExtensions
{
    public static IServiceCollection InjectDependencies(this IServiceCollection services)
    {
        services.AddControllers();

        return services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
             {
                 options.SchemaFilter<EnumSchemaFilter>();
             })
            .InjectCore()
            .InjectDrivenAdapters();
    }
}