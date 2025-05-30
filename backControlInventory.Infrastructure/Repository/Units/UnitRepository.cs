using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Context;
using backControlInventory.Infrastructure.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace backControlInventory.Infrastructure.Repository.Units;

public class UnitRepository : BaseRepository<Unit>, IUnitRepository
{

    public UnitRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<Unit> GetUnitByZipCode(string zipCode)
    {
        var normalizedZip = zipCode.Replace("-", "").Trim();

        var unit = await _context.Units
            .Include(u => u.Address)
            .FirstOrDefaultAsync(u =>
                u.Address != null &&
                u.Address.ZipCode.Replace("-", "").Trim() == normalizedZip);

        return unit;
    }
}