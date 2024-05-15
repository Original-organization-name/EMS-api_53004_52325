using System.ComponentModel;

namespace EMS.DTO.Records;

[DisplayName("Qualification")]
public record QualificationDto(
    Guid QualificationItemId,
    DateTime? ExpirationDate = null);
