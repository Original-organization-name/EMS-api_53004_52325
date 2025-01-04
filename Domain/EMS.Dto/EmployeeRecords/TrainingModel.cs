namespace EMS.Dto.EmployeeRecords;

public record TrainingModel(
    Guid Id,
    Guid EmployeeId,
    Guid TrainingItemId,
    string TrainingItem,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
