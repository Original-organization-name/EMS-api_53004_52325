using System.ComponentModel;

namespace EMS.DTO.Records;

[DisplayName("Training")]
public record TrainingDto(
    Guid TrainingItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
