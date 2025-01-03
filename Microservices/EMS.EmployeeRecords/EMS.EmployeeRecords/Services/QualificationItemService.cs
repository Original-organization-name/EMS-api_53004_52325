using EMS.Domain.Services;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.Services;

public class QualificationItemService : BaseEditableDictService<QualificationItem>, IQualificationItemService
{
    public QualificationItemService(IQualificationItemRepository repository) : base(repository)
    {
    }
}