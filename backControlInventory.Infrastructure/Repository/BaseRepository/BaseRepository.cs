
using backControlInventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace backControlInventory.Infrastructure.Repository.BaseRepository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationContext _context;

    public BaseRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}