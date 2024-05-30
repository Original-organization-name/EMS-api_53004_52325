using EMS.PersistenceLayer.Repositories;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;

namespace EMS.PersistenceLayer;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IEmployeeRepository> _lazyEmployeeRepository;
    private readonly Lazy<IMedicalExaminationRepository> _lazyMedicalExaminationRepository;
    private readonly Lazy<ITrainingRepository> _lazyTrainingRepository;
    private readonly Lazy<IQualificationRepository> _lazyQualificationRepository;
    private readonly Lazy<IEducationRepository> _lazyEducationRepository;
    private readonly Lazy<IOccupationDictRepository> _lazyOccupationRepository;
    private readonly Lazy<IContractRepository> _lazyContractRepository;
    private readonly Lazy<IImageRepository> _lazyImageRepository;

    public RepositoryManager(DatabaseContext dbContext)
    {
        _lazyMedicalExaminationRepository =  new Lazy<IMedicalExaminationRepository>(() => new MedicalExaminationRepository(dbContext));
        _lazyTrainingRepository =  new Lazy<ITrainingRepository>(() => new TrainingRepository(dbContext));
        _lazyQualificationRepository =  new Lazy<IQualificationRepository>(() => new QualificationRepository(dbContext));
        _lazyEmployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
        _lazyEducationRepository = new Lazy<IEducationRepository>(() => new EducationRepository(dbContext));
        _lazyOccupationRepository = new Lazy<IOccupationDictRepository>(() => new OccupationDictRepository(dbContext));
        _lazyContractRepository = new Lazy<IContractRepository>(() => new ContractRepository(dbContext));
        _lazyImageRepository = new Lazy<IImageRepository>(() => new ImageRepository(dbContext));
    }

    public IEmployeeRepository EmployeeRepository => _lazyEmployeeRepository.Value;
    public IMedicalExaminationRepository MedicalExaminationRepository => _lazyMedicalExaminationRepository.Value;
    public ITrainingRepository TrainingRepository => _lazyTrainingRepository.Value;
    public IQualificationRepository QualificationRepository => _lazyQualificationRepository.Value;
    public IEducationRepository EducationRepository => _lazyEducationRepository.Value;
    public IOccupationDictRepository OccupationDictRepository => _lazyOccupationRepository.Value;
    public IContractRepository ContractRepository => _lazyContractRepository.Value;
    public IImageRepository ImageRepository => _lazyImageRepository.Value;
}