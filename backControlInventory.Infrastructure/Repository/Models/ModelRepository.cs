using Microsoft.EntityFrameworkCore;
using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Context;
using backControlInventory.Infrastructure.Repository.BaseRepository;

namespace backControlInventory.Infrastructure.Models;

public class ModelRepository : BaseRepository<Model>, IModelRepository
{
    private readonly ApplicationContext _context;

    public ModelRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Model?> GetById(int id)
    {
        return await _context.Models
            .Include(m => m.Manufacturer)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    
    public override async Task<IEnumerable<Model>> GetAll()
    {
        return await _context.Models
        .Include(m => m.Manufacturer)
        .ToListAsync();
    }
}