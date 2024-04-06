using System.ComponentModel;

namespace EMS.Contracts.Records;

[DisplayName("Qualification")]
public record QualificationDto(
    Guid QualificationItemId,
    DateTime? ExpirationDate = null);
