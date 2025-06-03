using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Context;
using backControlInventory.Infrastructure.Repository.BaseRepository;
using backControlInventory.Infrastructure.Repository.Buildings;
using Microsoft.EntityFrameworkCore;

namespace backControlInventory.Infrastructure.Repository.Departments;

public class BuildingRepository : BaseRepository<Building>, IBuildingRepository
{
    private readonly ApplicationContext _context;

    public BuildingRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Building> GetById(int id)
    {
        return await _context.Buildings
            .Include(b => b.Unit)
            .Include(b => b.Departments)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public override async Task<IEnumerable<Building>> GetAll()
    {
        return await _context.Buildings
            .Include(b => b.Unit)
            .Include(b => b.Departments)
            .ToListAsync();
    }
}