using System.ComponentModel;
using EMS.Data.Contracts.Enums;

namespace EMS.DTO.Contracts;

[DisplayName("Contract")]
public record ContractDto(
    DateTime EmploymentDate, 
    DateTime ConclusionDate,
    Guid? PositionItemId,
    Guid? WorkplaceItemId,
    string? OccupationCodeItemId,
    DateTime StartDate,
    DateTime? TerminationDate,
    int FteNumerator,
    int FteDenominator,
    decimal Salary,
    SalaryType SalaryType,
    ContractType ContractType
);