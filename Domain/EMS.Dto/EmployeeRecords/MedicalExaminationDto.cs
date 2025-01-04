using System.ComponentModel;

namespace EMS.Dto.EmployeeRecords;

[DisplayName("MedicalExamination")]
public record MedicalExaminationDto(
    Guid MedicalExamItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
