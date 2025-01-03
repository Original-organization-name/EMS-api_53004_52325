using System.ComponentModel;

namespace EMS.EmployeeRecords.Models;

[DisplayName("Training")]
public record TrainingDto(
    Guid TrainingItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
