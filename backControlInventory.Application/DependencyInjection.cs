using Microsoft.Extensions.DependencyInjection;

namespace backControlInventory.Application;

public static class DependencyInjection {
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //services.AddScoped<>();

        return services;
    }
}