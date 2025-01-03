using EMS.Shared.Repositories;
using EMS.EmployeeRecords.Domain;

namespace EMS.EmployeeRecords.Abstractions.Repositories;

public interface IMedicalExaminationRepository : IBaseRepository<MedicalExamination>
{
    IQueryable<MedicalExamination> GetAll(Guid employeeId);
}