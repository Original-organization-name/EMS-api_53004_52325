using EMS.Shared.Interceptors;
using EMS.Employees.Domain;
using EMS.Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Employees.PersistenceLayer;

public class EmployeeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Database=ems_employees;Username=admin;Password=V22{5ntqm3X");
        optionsBuilder.AddInterceptors(new SaveAuditInterceptor());
    }
}