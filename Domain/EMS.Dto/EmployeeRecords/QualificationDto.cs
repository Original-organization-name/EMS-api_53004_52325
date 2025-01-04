using System.ComponentModel;

namespace EMS.Dto.EmployeeRecords;

[DisplayName("Qualification")]
public record QualificationDto(
    Guid QualificationItemId,
    DateTime? ExpirationDate = null);
