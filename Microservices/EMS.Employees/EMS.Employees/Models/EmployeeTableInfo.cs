using EMS.Domain.Shared;

namespace EMS.Employees.Models;

public class EmployeeTableInfo : EmployeeShortInfoModel
{
    public string? Position { get; set; }
    public string? Workplace { get; set; }
    public DateTime? ContractStartDate { get; init; }
    public Status? BhpStatus { get; init; }
    public Status? MedicalExamStatus { get; init; }
}