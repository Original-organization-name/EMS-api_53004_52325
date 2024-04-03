using EMS.Data.Records;

namespace EMS.Shared.Repositories;

public interface IMedicalExaminationRepository : IBaseRepository<MedicalExamination>
{
    IQueryable<MedicalExamination> GetAll(Guid employeeId);
}