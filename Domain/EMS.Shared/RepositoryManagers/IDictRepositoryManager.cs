using EMS.Data.Dictionaries;
using EMS.Shared.Repositories;

namespace EMS.Shared.RepositoryManagers;

public interface IDictRepositoryManager
{
    IBaseEditableDictRepository<MedicalExamItem> MedicalExamItemRepository { get; }
    IBaseEditableDictRepository<TrainingItem> TrainingItemRepository { get; }
    IBaseEditableDictRepository<QualificationItem> QualificationItemRepository { get; }
}