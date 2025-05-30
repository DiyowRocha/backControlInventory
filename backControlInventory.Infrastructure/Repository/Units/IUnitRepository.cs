using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Repository.BaseRepository;

namespace backControlInventory.Infrastructure.Repository.Units;

public interface IUnitRepository : IBaseRepository<Unit>
{
    Task<Unit> GetUnitByZipCode(string zipCode);
}