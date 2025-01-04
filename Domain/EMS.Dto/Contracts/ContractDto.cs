using System.ComponentModel;
using EMS.Shared.Enums;

namespace EMS.Dto.Contracts;

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