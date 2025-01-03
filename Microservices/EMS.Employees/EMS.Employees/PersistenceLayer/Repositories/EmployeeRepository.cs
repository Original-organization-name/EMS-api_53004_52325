using EMS.Shared.Repositories;
using EMS.Employees.Abstractions.Repositories;
using EMS.Employees.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMS.Employees.PersistenceLayer.Repositories;

public class EmployeeRepository : BaseRepository<EmployeeDbContext, Employee>, IEmployeeRepository
{
    public EmployeeRepository(EmployeeDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<Employee> GetAll()
    {
        return base.GetAll()
            .Include(employee => employee.Address)
            .Include(employee => employee.PaymentMethod);
    }

    public async Task<bool> IsPeselExist(string? pesel)
    {
        if (string.IsNullOrWhiteSpace(pesel)) return false;
        return await ExistsAsync(x => x.Pesel == pesel);
    }
}