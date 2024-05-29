using EMS.DTO.Employee;
using EMS.DTO.Records;

namespace EMS.Presentation.RequestModels;

public record CreateEmployeeModel(
    EmployeeDto Employee,
    List<MedicalExaminationDto>? MedicalExaminations,
    List<TrainingDto>? Trainings);