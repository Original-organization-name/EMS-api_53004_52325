using System.ComponentModel;

namespace EMS.Contracts.Records;

[DisplayName("Training")]
public record TrainingDto(
    Guid TrainingItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
