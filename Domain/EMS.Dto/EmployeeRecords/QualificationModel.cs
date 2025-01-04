namespace EMS.Dto.EmployeeRecords;

public record QualificationModel(
    Guid Id,
    Guid EmployeeId,
    Guid QualificationItemId,
    string QualificationItem,
    DateTime? ExpirationDate = null);
