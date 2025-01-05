using EMS.Dto.EmployeeRecords;
using EMS.Shared.Shared;

namespace EMS.EmployeeRecords.Abstractions.Services;

public interface ITrainingService
{
    Task<IReadOnlyList<TrainingModel>> GetAllAsync(Guid employeeId);
    Task<TrainingModel?> GetById(Guid id);
    Task<TrainingModel> AddAsync(Guid employeeId, TrainingDto training);
    Task<RecordStatus?> GetBhpStatusAsync(Guid employeeId);
    Task<IEnumerable<TrainingModel>> DeleteEmployeeTrainingsAsync(Guid employeeId);
}