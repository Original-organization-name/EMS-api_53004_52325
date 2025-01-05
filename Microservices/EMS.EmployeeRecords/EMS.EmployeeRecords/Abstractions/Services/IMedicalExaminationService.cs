using EMS.Dto.EmployeeRecords;

namespace EMS.EmployeeRecords.Abstractions.Services;

public interface IMedicalExaminationService 
{
    Task<IReadOnlyList<MedicalExaminationModel>> GetAllAsync(Guid employeeId);
    Task<MedicalExaminationModel?> GetById(Guid id);
    Task<MedicalExaminationModel> AddAsync(Guid employeeId, MedicalExaminationDto medicalExamination);
    Task<IEnumerable<MedicalExaminationModel>> DeleteEmployeeExamsAsync(Guid employeeId);
}