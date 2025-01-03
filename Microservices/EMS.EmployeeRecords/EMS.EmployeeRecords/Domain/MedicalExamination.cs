using EMS.Domain.Abstractions;
using EMS.Domain.Models;
using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.Domain;

public class MedicalExamination : Entity, IAggregateRoot
{
    public required Guid EmployeeId { get; set; }
    
    public required Guid MedicalExamItemId { get; set; }
    public MedicalExamItem MedicalExamItem { get; set; } = null!;
    
    public required DateTime ExecutionDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
}