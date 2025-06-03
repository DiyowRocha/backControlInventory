using backControlInventory.Infrastructure.Context;
using backControlInventory.Infrastructure.Models;
using backControlInventory.Infrastructure.Repository.BaseRepository;
using backControlInventory.Infrastructure.Repository.Buildings;
using backControlInventory.Infrastructure.Repository.Departments;
using backControlInventory.Infrastructure.Repository.Devices;
using backControlInventory.Infrastructure.Repository.Manufacturers;
using backControlInventory.Infrastructure.Repository.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backControlInventory.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationContext>(options
        => options.UseNpgsql(connectionString));

        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IBuildingRepository, BuildingRepository>();
        services.AddScoped<IDeviceRepository, DeviceRepository>();

        return services;
    }
}