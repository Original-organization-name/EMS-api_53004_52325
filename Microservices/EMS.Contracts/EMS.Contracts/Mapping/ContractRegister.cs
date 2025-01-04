using EMS.Contracts.Domain.Entities;
using EMS.Dto.Contracts;
using Mapster;

namespace EMS.Contracts.Mapping;

public class ContractRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ContractDto, Contract>()
            .Map(dest => dest.EmploymentDate, src => src.EmploymentDate)
            .Map(dest => dest.ConclusionDate, src => src.ConclusionDate)
            .Map(dest => dest.PositionItemId, src => src.PositionItemId)
            .Map(dest => dest.WorkplaceItemId, src => src.WorkplaceItemId)
            .Map(dest => dest.OccupationCodeItemId, src => src.OccupationCodeItemId)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.TerminationDate, src => src.TerminationDate)
            .Map(dest => dest.FteNumerator, src => src.FteNumerator)
            .Map(dest => dest.FteDenominator, src => src.FteDenominator)
            .Map(dest => dest.Salary, src => src.Salary)
            .Map(dest => dest.SalaryType, src => src.SalaryType)
            .Map(dest => dest.ContractType, src => src.ContractType);
        
        
        config.NewConfig<Contract, ContractModel>()
            .Map(dest => dest.EmploymentDate, src => src.EmploymentDate)
            .Map(dest => dest.ConclusionDate, src => src.ConclusionDate)
            .Map(dest => dest.PositionItemId, src => src.PositionItemId)
            .Map(dest => dest.PositionItemName, src => src.PositionItem.Value)
            .Map(dest => dest.WorkplaceItemId, src => src.WorkplaceItemId)
            .Map(dest => dest.WorkplaceItemName, src => src.WorkplaceItem.Value)
            .Map(dest => dest.OccupationCodeItemId, src => src.OccupationCodeItemId)
            .Map(dest => dest.OccupationCodeName, src => src.OccupationCodeItem.Value)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.TerminationDate, src => src.TerminationDate)
            .Map(dest => dest.FteNumerator, src => src.FteNumerator)
            .Map(dest => dest.FteDenominator, src => src.FteDenominator)
            .Map(dest => dest.Salary, src => src.Salary)
            .Map(dest => dest.SalaryType, src => src.SalaryType)
            .Map(dest => dest.ContractType, src => src.ContractType);
    }
}