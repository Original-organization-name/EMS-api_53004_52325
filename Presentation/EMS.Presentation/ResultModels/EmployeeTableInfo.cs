using EMS.Data.Shared;

namespace EMS.Presentation.ResultModels;

public class EmployeeTableInfo : EmployeeShortInfoModel
{
    public string? Position { get; set; }
    public string? Workplace { get; set; }
    public DateTime? ContractStartDate { get; init; }
    public Status? BhpStatus { get; init; }
    public Status? MedicalExamStatus { get; init; }
}