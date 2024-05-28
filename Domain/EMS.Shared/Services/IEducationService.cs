using EMS.DTO.Education;

namespace EMS.Shared.Services;

public interface IEducationService
{
    Task<IReadOnlyList<EducationModel>> GetAllEmployeeEducation(Guid employeeId);
    Task<EducationModel?> GetById(Guid id);
    Task<EducationModel> Add(Guid employeeId, EducationDto Education);
}