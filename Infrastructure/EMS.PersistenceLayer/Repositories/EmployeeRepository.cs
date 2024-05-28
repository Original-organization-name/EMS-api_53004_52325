using EMS.Data.Employees;
using EMS.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DatabaseContext dbContext) : base(dbContext)
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