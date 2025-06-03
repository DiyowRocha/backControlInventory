using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Context;
using backControlInventory.Infrastructure.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace backControlInventory.Infrastructure.Repository.Departments;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    private readonly ApplicationContext _context;

    public DepartmentRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Department>> GetAll()
    {
        return await _context.Departments
            .Include(d => d.Building)
            .ToListAsync();
    }

    public override async Task<Department?> GetById(int id)
    {
        return await _context.Departments
            .Include(b => b.Building)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}