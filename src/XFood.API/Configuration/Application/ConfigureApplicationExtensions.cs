using Microsoft.Extensions.DependencyInjection.Extensions;
using xFood.Infrastructure;

namespace XFood.API.Configuration.Application;

public static class ConfigureApplicationExtensions
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.TryAddScoped<ICommandDispatcher, CommandDispatcher>();
        services.TryAddScoped<IQueryDispatcher, QueryDispatcher>();

        services.Scan(selector =>
            selector.FromCallingAssembly()
                .AddClasses(filter =>
                    filter.AssignableTo(typeof(IQueryHandler<,>))
                ).AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        services.Scan(selector =>
            selector.FromCallingAssembly()
                .AddClasses(filter =>
                    filter.AssignableTo(typeof(ICommandHandler<,>))
                ).AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        return services;
    }
}