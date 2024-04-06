namespace EMS.Shared.Services;

public interface IServiceManager
{
    IEmployeeService EmployeeService { get; }
    IMedicalExaminationService MedicalExaminationService { get; }
    IQualificationService QualificationService { get; }
    ITrainingService TrainingService { get; }
    
    ITrainingDictService TrainingDictService { get; }
    IMedicalExaminationDictService MedicalExaminationDictService { get; }
}
