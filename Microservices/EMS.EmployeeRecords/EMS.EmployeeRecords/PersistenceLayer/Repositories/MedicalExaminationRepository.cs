using EMS.Shared.Repositories;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMS.EmployeeRecords.PersistenceLayer.Repositories;

public class MedicalExaminationRepository : BaseRepository<RecordsDbContext, MedicalExamination>, IMedicalExaminationRepository
{
    public MedicalExaminationRepository(RecordsDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<MedicalExamination> GetAll()
    {
        return base.GetAll()
            .Include(item => item.MedicalExamItem);
    }

    public IQueryable<MedicalExamination> GetAll(Guid employeeId)
    {
        return GetAll().Where(item => item.EmployeeId == employeeId);
    }
}