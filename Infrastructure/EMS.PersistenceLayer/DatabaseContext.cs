using EMS.Data.Contracts;
using EMS.Data.Dictionaries;
using EMS.Data.Education;
using EMS.Data.Employees;
using EMS.Data.Employees.Entities;
using EMS.Data.Records;
using EMS.PersistenceLayer.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer;

public class DatabaseContext : DbContext
{
    // Personal data
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    
    // Records
    public DbSet<MedicalExamination> MedicalExaminations { get; set; } = null!;
    public DbSet<Training> Trainings { get; set; } = null!;
    public DbSet<Qualification> Qualifications { get; set; } = null!;

    // Cotracts
    public DbSet<Contract> Contracts { get; set; } = null!;
    
    // Dictionaries
    public DbSet<QualificationItem> QualificationDict { get; set; } = null!;
    public DbSet<MedicalExamItem> MedicalExamDict { get; set; } = null!;
    public DbSet<TrainingItem> TrainingDict { get; set; } = null!;
    public DbSet<PositionItem> PositionDict { get; set; } = null!;
    public DbSet<WorkplaceItem> WorkplaceDict { get; set; } = null!;
    public DbSet<OccupationCodeItem> OccupationCodeDict { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Database=ems_test;Username=admin;Password=V22{5ntqm3X");
        optionsBuilder.AddInterceptors(new SaveAuditInterceptor());
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Education>()
            .OwnsOne(p => p.Period);
        
        modelBuilder.Entity<OccupationCodeItem>()
            .HasKey(p => p.Code);
    }
}