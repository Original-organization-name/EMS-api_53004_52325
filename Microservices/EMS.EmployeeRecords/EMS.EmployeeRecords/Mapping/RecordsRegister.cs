using EMS.EmployeeRecords.Domain;
using EMS.EmployeeRecords.Models;
using Mapster;

namespace EMS.EmployeeRecords.Mapping;

public class RecordsRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MedicalExaminationDto, MedicalExamination>()
            .Map(dest => dest.MedicalExamItemId, src => src.MedicalExamItemId)
            .Map(dest => dest.ExecutionDate, src => src.ExecutionDate)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate);
        
        config.NewConfig<MedicalExamination, MedicalExaminationModel>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EmployeeId, src => src.EmployeeId)
            .Map(dest => dest.MedicalExamItemId, src => src.MedicalExamItem.Id)
            .Map(dest => dest.MedicalExamItem, src => src.MedicalExamItem.Value)
            .Map(dest => dest.ExecutionDate, src => src.ExecutionDate)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate);
        
        config.NewConfig<TrainingDto, Training>()
            .Map(dest => dest.TrainingItemId, src => src.TrainingItemId)
            .Map(dest => dest.ExecutionDate, src => src.ExecutionDate)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate);
        
        config.NewConfig<Training, TrainingModel>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EmployeeId, src => src.EmployeeId)
            .Map(dest => dest.TrainingItemId, src => src.TrainingItem.Id)
            .Map(dest => dest.TrainingItem, src => src.TrainingItem.Value)
            .Map(dest => dest.ExecutionDate, src => src.ExecutionDate)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate);
        
        config.NewConfig<QualificationDto, Qualification>()
            .Map(dest => dest.QualificationItemId, src => src.QualificationItemId)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate);
        
        config.NewConfig<Qualification, QualificationModel>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EmployeeId, src => src.EmployeeId)
            .Map(dest => dest.QualificationItemId, src => src.QualificationItem.Id)
            .Map(dest => dest.QualificationItem, src => src.QualificationItem.Value)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate);
    }
}    