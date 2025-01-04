using System.ComponentModel;

namespace EMS.Dto.EmployeeRecords;

[DisplayName("Training")]
public record TrainingDto(
    Guid TrainingItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
