using EMS.DTO.Dictionaries;
using EMS.Data.Dictionaries;
using Mapster;

namespace EMS.DTO.Mapster;

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