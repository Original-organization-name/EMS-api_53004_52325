using EMS.Shared.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace EMS.Education.PersistenceLayer;

public class EducationDbContext : DbContext
{
    // Dictionaries
    public DbSet<Domain.Education> Education { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Database=ems_education;Username=admin;Password=V22{5ntqm3X");
        optionsBuilder.AddInterceptors(new SaveAuditInterceptor());
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Education>()
            .OwnsOne(p => p.Period);
    }
}