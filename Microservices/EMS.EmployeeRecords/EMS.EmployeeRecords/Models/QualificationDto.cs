using System.ComponentModel;

namespace EMS.EmployeeRecords.Models;

[DisplayName("Qualification")]
public record QualificationDto(
    Guid QualificationItemId,
    DateTime? ExpirationDate = null);
