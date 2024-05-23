using EMS.Data.Dictionaries;
using EMS.Data.Employees;
using EMS.Data.Employees.Entities;
using EMS.Data.Experience;
using EMS.Data.Records;
using EMS.PersistenceLayer.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer;

public class DatabaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
    
    public DbSet<MedicalExamination> MedicalExaminations { get; set; } = null!;
    public DbSet<Training> Trainings { get; set; } = null!;
    public DbSet<Qualification> Qualifications { get; set; } = null!;
    
    public DbSet<QualificationItem> QualificationDict { get; set; } = null!;
    public DbSet<MedicalExamItem> MedicalExamDict { get; set; } = null!;
    public DbSet<TrainingItem> TrainingDict { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Database=ems_test;Username=admin;Password=V22{5ntqm3X");
        optionsBuilder.AddInterceptors(new SaveAuditInterceptor());
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Education>()
            .OwnsOne(p => p.Period);
    }
}