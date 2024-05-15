namespace EMS.DTO.Records;

public record QualificationModel(
    Guid Id,
    Guid EmployeeId,
    Guid QualificationItemId,
    string QualificationItem,
    DateTime? ExpirationDate = null);
