using EMS.PersistenceLayer.Repositories;
using EMS.Shared.Repositories;

namespace EMS.PersistenceLayer;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IEmployeeRepository> _lazyEmployeeRepository;

    public RepositoryManager(DatabaseContext dbContext)
    {
        _lazyEmployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
    }

    public IEmployeeRepository EmployeeRepository => _lazyEmployeeRepository.Value;
}