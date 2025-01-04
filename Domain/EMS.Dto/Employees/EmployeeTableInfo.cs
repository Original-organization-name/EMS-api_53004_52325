using EMS.Shared.Shared;

namespace EMS.Dto.Employees;

public class EmployeeTableInfo : EmployeeShortInfoModel
{
    public string? Position { get; set; }
    public string? Workplace { get; set; }
    public DateTime? ContractStartDate { get; init; }
    public RecordStatus? BhpStatus { get; init; }
    public RecordStatus? MedicalExamStatus { get; init; }
}