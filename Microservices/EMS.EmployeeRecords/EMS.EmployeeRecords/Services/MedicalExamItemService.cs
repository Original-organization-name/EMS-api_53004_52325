using EMS.Domain.Services;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.Services;

public class MedicalExamItemService : BaseEditableDictService<MedicalExamItem>, IMedicalExamItemService
{
    public MedicalExamItemService(IMedicalExamItemRepository repository) : base(repository)
    {
    }
}