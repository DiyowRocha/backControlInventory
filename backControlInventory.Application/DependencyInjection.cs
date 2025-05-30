using backControlInventory.Application.External.ViaCep;
using backControlInventory.Application.Service.Units;
using Microsoft.Extensions.DependencyInjection;

namespace backControlInventory.Application;

public static class DependencyInjection {
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IViaCepService, ViaCepService>();
        services.AddScoped<IUnitService, UnitService>();

        return services;
    }
}