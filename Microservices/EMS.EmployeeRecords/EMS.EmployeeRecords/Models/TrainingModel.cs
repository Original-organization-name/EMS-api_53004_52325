namespace EMS.EmployeeRecords.Models;

public record TrainingModel(
    Guid Id,
    Guid EmployeeId,
    Guid TrainingItemId,
    string TrainingItem,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
