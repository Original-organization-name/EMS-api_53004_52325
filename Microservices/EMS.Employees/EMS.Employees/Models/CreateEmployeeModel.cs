namespace EMS.Employees.Models;

public record CreateEmployeeModel(
    EmployeeDto Employee,
    //ContractDto? Contract,
    //List<MedicalExaminationDto>? MedicalExaminations,
    //List<TrainingDto>? Trainings,
    string? ImageBase64);