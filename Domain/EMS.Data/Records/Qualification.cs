using EMS.Data.Abstractions;
using EMS.Data.Dictionaries;
using EMS.Data.Employees;
using EMS.Data.Models;

namespace EMS.Data.Records;

public class Qualification : Entity, IAggregateRoot
{
    public Guid QualificationItemId { get; set; }
    public QualificationItem QualificationItem { get; set; } = null!;
    
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    
    public DateTime? ExpirationDate { get; set; }
}