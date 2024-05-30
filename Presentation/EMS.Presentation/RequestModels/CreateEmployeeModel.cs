using EMS.DTO.Contracts;
using EMS.DTO.Employee;
using EMS.DTO.Records;

namespace EMS.Presentation.RequestModels;

public record CreateEmployeeModel(
    EmployeeDto Employee,
    ContractDto? Contract,
    List<MedicalExaminationDto>? MedicalExaminations,
    List<TrainingDto>? Trainings,
    string? ImageBase64);