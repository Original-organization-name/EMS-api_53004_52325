namespace EMS.Contracts.Records;

public record QualificationDto(
    Guid QualificationItemId,
    DateTime? ExpirationDate = null);
