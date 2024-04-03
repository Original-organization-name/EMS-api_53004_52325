using EMS.Data.Abstractions;
using EMS.Data.Dictionaries;
using EMS.Data.Employees;
using EMS.Data.Models;

namespace EMS.Data.Records;

public class MedicalExamination : Entity, IAggregateRoot
{
    public required Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    
    public required Guid MedicalExamItemId { get; set; }
    public MedicalExamItem MedicalExamItem { get; set; } = null!;
    
    public required DateTime ExecutionDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
}