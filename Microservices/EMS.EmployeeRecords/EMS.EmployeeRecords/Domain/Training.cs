using EMS.Domain.Abstractions;
using EMS.Domain.Models;
using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.Domain;

public class Training : Entity, IAggregateRoot
{
    public required Guid EmployeeId { get; set; }
    
    public required Guid TrainingItemId { get; set; }
    public TrainingItem TrainingItem { get; set; } = null!;
    
    public required DateTime ExecutionDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
}