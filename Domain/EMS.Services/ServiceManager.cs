using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;

namespace EMS.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmployeeService> _lazyEmployeeService;
    private readonly Lazy<IMedicalExaminationService> _lazyMedicalExaminationService;
    private readonly Lazy<IQualificationService> _lazyQualificationService;
    private readonly Lazy<ITrainingService> _lazyTrainingService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyEmployeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager));
        _lazyMedicalExaminationService = new Lazy<IMedicalExaminationService>(() => new MedicalExaminationService(repositoryManager));
        _lazyQualificationService = new Lazy<IQualificationService>(() => new QualificationService(repositoryManager));
        _lazyTrainingService = new Lazy<ITrainingService>(() => new TrainingService(repositoryManager));
    }

    public IEmployeeService EmployeeService => _lazyEmployeeService.Value;
    public IMedicalExaminationService MedicalExaminationService => _lazyMedicalExaminationService.Value;
    public IQualificationService QualificationService => _lazyQualificationService.Value;
    public ITrainingService TrainingService => _lazyTrainingService.Value;
}