using System.ComponentModel;

namespace EMS.DTO.Records;

[DisplayName("MedicalExamination")]
public record MedicalExaminationDto(
    Guid MedicalExamItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
