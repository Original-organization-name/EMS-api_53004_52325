using EMS.Contracts.Records;

namespace EMS.Shared.Services;

public interface IQualificationService
{
    Task<IReadOnlyList<QualificationModel>> GetAll(Guid employeeId);
    Task<QualificationModel?> GetById(Guid id);
    Task<QualificationModel> Add(Guid employeeId, QualificationDto qualificationDto);
}