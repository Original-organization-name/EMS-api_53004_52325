using EMS.Data.Records;
using EMS.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer.Repositories;

public class MedicalExaminationRepository : BaseRepository<MedicalExamination>, IMedicalExaminationRepository
{
    public MedicalExaminationRepository(DatabaseContext dbContext) : base(dbContext)
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