using EMS.Data.Models;
using EMS.DTO.Education;
using Mapster;

namespace EMS.DTO.Mapster;

public class ExperienceRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid employeeId, EducationDto dto), Data.Education.Education>()
            .Map(dest => dest.EmployeeId, src => src.employeeId)
            .Map(dest => dest.SchoolName, src => src.dto.SchoolName)
            .Map(dest => dest.Type, src => src.dto.Type)
            .Map(dest => dest.Period, src => new TerminalDatePeriod(src.dto.Start, src.dto.End))
            .Map(dest => dest.Degree, src => src.dto.Degree)
            .Map(dest => dest.Occupation, src => src.dto.Occupation);
        
        config.NewConfig<Data.Education.Education, EducationModel>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.SchoolName, src => src.SchoolName)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.Start, src => src.Period.Start)
            .Map(dest => dest.End, src => src.Period.End)
            .Map(dest => dest.Degree, src => src.Degree)
            .Map(dest => dest.Occupation, src => src.Occupation);
    }
}    