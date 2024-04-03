namespace EMS.Contracts.Records;

public record MedicalExaminationDto(
    Guid MedicalExamItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
