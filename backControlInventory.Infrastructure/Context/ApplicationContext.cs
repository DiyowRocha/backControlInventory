using backControlInventory.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace backControlInventory.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Device> Devices { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Department> Departments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>().OwnsOne(d => d.NetworkInfo);
        modelBuilder.Entity<Device>().OwnsOne(d => d.ChipInfo);
        modelBuilder.Entity<Unit>().OwnsOne(u => u.Address);

        base.OnModelCreating(modelBuilder);
    }
}