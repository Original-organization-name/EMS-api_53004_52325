using EMS.Shared.Abstractions.Dictionaries;
using EMS.EmployeeRecords.Domain.Dictionaries;
using Mapster;

namespace EMS.EmployeeRecords.Mapping;

public class DictionaryRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DictionaryItemDto, MedicalExamItem>()
            .ConstructUsing(src => new MedicalExamItem()
            {
                Value = src.Value
            });
        
        config.NewConfig<DictionaryItemDto, QualificationItem>()
            .ConstructUsing(src => new QualificationItem()
            {
                Value = src.Value
            });
        
        config.NewConfig<DictionaryItemDto, TrainingItem>()
            .ConstructUsing(src => new TrainingItem()
            {
                Value = src.Value
            });
    }
}