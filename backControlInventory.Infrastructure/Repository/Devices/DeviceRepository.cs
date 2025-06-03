using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Context;
using backControlInventory.Infrastructure.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace backControlInventory.Infrastructure.Repository.Devices;

public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
{
    private readonly ApplicationContext _context;

    public DeviceRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Device?> GetById(int id)
    {
        return await _context.Devices
            .Include(d => d.Manufacturer)
            .Include(d => d.Model)
            .Include(d => d.NetworkInfo)
            .Include(d => d.ChipInfo)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public override async Task<IEnumerable<Device?>> GetAll()
    {
        return await _context.Devices
            .Include(d => d.Manufacturer)
            .Include(d => d.Model)
            .Include(d => d.NetworkInfo)
            .Include(d => d.ChipInfo)
            .ToListAsync();
    }
}