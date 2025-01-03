using System.ComponentModel;

namespace EMS.EmployeeRecords.Models;

[DisplayName("MedicalExamination")]
public record MedicalExaminationDto(
    Guid MedicalExamItemId,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
