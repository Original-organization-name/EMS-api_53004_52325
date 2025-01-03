using EMS.Contracts.Domain.Dictionaries;
using EMS.Contracts.Domain.Entities;
using EMS.Shared.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace EMS.Contracts.PersistenceLayer;

public class ContractsDbContext : DbContext
{
    public DbSet<Contract> Contracts { get; set; } = null!;
    
    public DbSet<OccupationCodeItem> OccupationCodeDict { get; set; } = null!;
    
    public DbSet<PositionItem> PositionDict { get; set; } = null!;
    
    public DbSet<WorkplaceItem> WorkplaceDict { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Database=ems_contracts;Username=admin;Password=V22{5ntqm3X");
        optionsBuilder.AddInterceptors(new SaveAuditInterceptor());
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OccupationCodeItem>()
            .HasKey(p => p.Code);
    }
}