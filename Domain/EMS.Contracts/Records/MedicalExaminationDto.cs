using System.ComponentModel;

namespace EMS.Contracts.Records;

[DisplayName("MedicalExamination")]
public record MedicalExaminationDto(
    Guid MedicalExamItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
