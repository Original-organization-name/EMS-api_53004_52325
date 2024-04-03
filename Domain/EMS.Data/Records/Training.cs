using EMS.Data.Abstractions;
using EMS.Data.Dictionaries;
using EMS.Data.Employees;
using EMS.Data.Models;

namespace EMS.Data.Records;

public class Training : Entity, IAggregateRoot
{
    public required Guid TrainingItemId { get; set; }
    public TrainingItem TrainingItem { get; set; } = null!;
    
    public required Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    
    public required DateTime ExecutionDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
}