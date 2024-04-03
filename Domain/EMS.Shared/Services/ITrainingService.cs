using EMS.Contracts.Records;

namespace EMS.Shared.Services;

public interface ITrainingService
{
    Task<IReadOnlyList<TrainingModel>> GetAll(Guid employeeId);
    Task<TrainingModel?> GetById(Guid id);
    Task<TrainingModel> Add(Guid employeeId, TrainingDto training);
}