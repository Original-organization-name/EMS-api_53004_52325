using EMS.Dto.Contracts;
using EMS.Dto.EmployeeRecords;

namespace EMS.Dto.Employees;

public record CreateEmployeeModel(
    EmployeeDto Employee,
    ContractDto? Contract,
    List<MedicalExaminationDto>? MedicalExaminations,
    List<TrainingDto>? Trainings,
    string? ImageBase64);