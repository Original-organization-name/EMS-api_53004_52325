namespace EMS.Shared.Repositories;

public interface IRepositoryManager
{
    IEmployeeRepository EmployeeRepository { get; }
}