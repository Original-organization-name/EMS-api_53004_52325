namespace EMS.Contracts.Records;

public record TrainingDto(
    Guid TrainingItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
