using EMS.Domain.Shared;
using EMS.EmployeeRecords.Models;

namespace EMS.EmployeeRecords.Abstractions.Services;

public interface ITrainingService
{
    Task<IReadOnlyList<TrainingModel>> GetAllAsync(Guid employeeId);
    Task<TrainingModel?> GetById(Guid id);
    Task<TrainingModel> Add(Guid employeeId, TrainingDto training);
    Task<Status?> GetBhpStatusAsync(Guid employeeId);
}