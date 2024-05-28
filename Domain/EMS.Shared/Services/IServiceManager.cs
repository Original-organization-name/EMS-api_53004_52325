using EMS.Data.Dictionaries;

namespace EMS.Shared.Services;

public interface IServiceManager
{
    IEmployeeService EmployeeService { get; }
    IMedicalExaminationService MedicalExaminationService { get; }
    IQualificationService QualificationService { get; }
    ITrainingService TrainingService { get; }
    IEducationService EducationService { get; }
    IOccupationDictService OccupationDictService { get; }
    IContractService ContractService { get; }
}
