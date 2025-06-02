using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Context;
using backControlInventory.Infrastructure.Repository.BaseRepository;

namespace backControlInventory.Infrastructure.Repository.Manufacturers;

public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
{
    public ManufacturerRepository(ApplicationContext context) : base(context)
    {
    }
}