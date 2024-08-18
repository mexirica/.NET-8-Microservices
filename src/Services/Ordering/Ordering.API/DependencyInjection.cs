using System.Reflection;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                ;
        });

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}