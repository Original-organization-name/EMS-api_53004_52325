using EMS.Shared.Repositories;
using EMS.Shared.Services;

namespace EMS.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmployeeService> _lazyEmployeeService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyEmployeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager));
    }

    public IEmployeeService EmployeeService => _lazyEmployeeService.Value;
}