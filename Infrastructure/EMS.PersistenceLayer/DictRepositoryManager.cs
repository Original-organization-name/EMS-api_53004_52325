using EMS.Data.Dictionaries;
using EMS.PersistenceLayer.Repositories;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;

namespace EMS.PersistenceLayer;

public class DictRepositoryManager : IDictRepositoryManager
{
    private readonly Lazy<IBaseEditableDictRepository<MedicalExamItem>> _lazyMedicalExamRepository;
    private readonly Lazy<IBaseEditableDictRepository<TrainingItem>> _lazyTrainingRepository;
    private readonly Lazy<IBaseEditableDictRepository<QualificationItem>> _lazyQualificationRepository;

    public DictRepositoryManager(DatabaseContext dbContext)
    {
        _lazyMedicalExamRepository =  new Lazy<IBaseEditableDictRepository<MedicalExamItem>>(() => 
            new BaseEditableDictRepository<MedicalExamItem>(dbContext));
        _lazyTrainingRepository =  new Lazy<IBaseEditableDictRepository<TrainingItem>>(() => 
            new BaseEditableDictRepository<TrainingItem>(dbContext));
        _lazyQualificationRepository =  new Lazy<IBaseEditableDictRepository<QualificationItem>>(() => 
            new BaseEditableDictRepository<QualificationItem>(dbContext));
    }

    public IBaseEditableDictRepository<MedicalExamItem> MedicalExamItemRepository => _lazyMedicalExamRepository.Value;
    public IBaseEditableDictRepository<TrainingItem> TrainingItemRepository => _lazyTrainingRepository.Value;
    public IBaseEditableDictRepository<QualificationItem> QualificationItemRepository => _lazyQualificationRepository.Value;
}