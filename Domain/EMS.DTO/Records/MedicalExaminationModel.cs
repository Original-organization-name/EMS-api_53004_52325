namespace EMS.DTO.Records;

public record MedicalExaminationModel(
    Guid Id,
    Guid EmployeeId,
    Guid MedicalExamItemId,
    string MedicalExamItem,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
