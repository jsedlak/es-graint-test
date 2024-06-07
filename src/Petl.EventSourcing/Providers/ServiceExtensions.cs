using Microsoft.Extensions.DependencyInjection;

namespace Petl.EventSourcing.Providers;

public static class ServiceExtensions
{
    public static void AddDummyEventSourcing(this IServiceCollection services)
    {
        services.AddScoped<IEventLogFactory, DummyMemoryEventLogFactory>();
    }
}