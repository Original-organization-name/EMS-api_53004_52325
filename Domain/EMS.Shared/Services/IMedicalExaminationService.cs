using EMS.Contracts.Records;

namespace EMS.Shared.Services;

public interface IMedicalExaminationService 
{
    Task<IReadOnlyList<MedicalExaminationModel>> GetAll(Guid employeeId);
    Task<MedicalExaminationModel?> GetById(Guid id);
    Task<MedicalExaminationModel> Add(Guid employeeId, MedicalExaminationDto medicalExamination);
}