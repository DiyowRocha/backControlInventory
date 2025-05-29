using Microsoft.EntityFrameworkCore;

namespace backControlInventory.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
}