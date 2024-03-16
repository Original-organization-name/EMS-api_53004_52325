using EMS.Data.Employee;
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
            .Include(employee => employee.PaymentMethod)
            .Include(employee => employee.Contacts);
    }

    public async Task<Employee?> GetById(Guid id)
    {
        return await GetAll()
            .FirstOrDefaultAsync(employee => employee.Id == id);
    }
}