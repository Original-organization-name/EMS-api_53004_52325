using EMS.Dto.Education;

namespace EMS.Education.Abstractions.Services;

public interface IEducationService
{
    Task<IReadOnlyList<EducationModel>> GetAllEmployeeEducationAsync(Guid employeeId);
    Task<EducationModel?> GetById(Guid id);
    Task<EducationModel> AddAsync(Guid employeeId, EducationDto education);
}