using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Context;
using backControlInventory.Infrastructure.Repository.BaseRepository;
using backControlInventory.Infrastructure.Repository.Buildings;

namespace backControlInventory.Infrastructure.Repository.Departments;

public class BuildingRepository : BaseRepository<Building>, IBuildingRepository
{
    public BuildingRepository(ApplicationContext context) : base(context)
    {
    }
}