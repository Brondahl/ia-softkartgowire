using Microsoft.EntityFrameworkCore;
using SoftKartGoWire.Models;

namespace SoftKartGoWire;

public class KartingContext : DbContext
{
    public KartingContext(DbContextOptions<KartingContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Driver> Drivers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        DefineTableNamesAsSingular<Team>(modelBuilder);
        DefineTableNamesAsSingular<Driver>(modelBuilder);
    }

    private void DefineTableNamesAsSingular<T>(ModelBuilder modelBuilder) where T : class
    {
        modelBuilder.Entity<T>().ToTable(typeof(T).Name);
    }
}
