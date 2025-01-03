using EMS.Shared.Abstractions;
using EMS.Shared.Models;
using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.Domain;

public class Qualification : Entity, IAggregateRoot
{
    public Guid EmployeeId { get; set; }
    
    public Guid QualificationItemId { get; set; }
    public QualificationItem QualificationItem { get; set; } = null!;
    
    public DateTime? ExpirationDate { get; set; }
}