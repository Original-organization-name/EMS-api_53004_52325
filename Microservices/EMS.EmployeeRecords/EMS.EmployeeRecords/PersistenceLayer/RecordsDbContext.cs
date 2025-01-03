using EMS.Shared.Interceptors;
using EMS.EmployeeRecords.Domain;
using EMS.EmployeeRecords.Domain.Dictionaries;
using Microsoft.EntityFrameworkCore;

namespace EMS.EmployeeRecords.PersistenceLayer;

public class RecordsDbContext : DbContext
{
    // Records
    public DbSet<MedicalExamination> MedicalExaminations { get; set; } = null!;
    public DbSet<Training> Trainings { get; set; } = null!;
    public DbSet<Qualification> Qualifications { get; set; } = null!;

    // Dictionaries
    public DbSet<QualificationItem> QualificationDict { get; set; } = null!;
    public DbSet<MedicalExamItem> MedicalExamDict { get; set; } = null!;
    public DbSet<TrainingItem> TrainingDict { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Database=ems_employee_records;Username=admin;Password=V22{5ntqm3X");
        optionsBuilder.AddInterceptors(new SaveAuditInterceptor());
    }
}