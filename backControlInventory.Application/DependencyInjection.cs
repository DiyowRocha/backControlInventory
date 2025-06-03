using backControlInventory.Application.External.ViaCep;
using backControlInventory.Application.Service.Buildings;
using backControlInventory.Application.Service.Departments;
using backControlInventory.Application.Service.Manufacturers;
using backControlInventory.Application.Service.Models;
using backControlInventory.Application.Service.Units;
using Microsoft.Extensions.DependencyInjection;

namespace backControlInventory.Application;

public static class DependencyInjection {
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IViaCepService, ViaCepService>();
        services.AddScoped<IUnitService, UnitService>();
        services.AddScoped<IManufacturerService, ManufacturerService>();
        services.AddScoped<IModelService, ModelService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IBuildingService, BuildingService>();

        return services;
    }
}