using EMS.Data.Employee;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer;

public class DatabaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ems_test;Username=admin;Password=V22{5ntqm3X");
}