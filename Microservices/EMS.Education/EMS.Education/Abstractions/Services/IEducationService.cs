using EMS.Education.Models;

namespace EMS.Education.Abstractions.Services;

public interface IEducationService
{
    Task<IReadOnlyList<EducationModel>> GetAllEmployeeEducationAsync(Guid employeeId);
    Task<EducationModel?> GetById(Guid id);
    Task<EducationModel> Add(Guid employeeId, EducationDto education);
}