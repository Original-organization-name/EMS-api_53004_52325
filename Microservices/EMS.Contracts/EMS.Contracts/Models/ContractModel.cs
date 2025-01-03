using EMS.Contracts.Domain.Enums;

namespace EMS.Contracts.Models;

public record ContractModel(
    Guid Id,
    DateTime EmploymentDate,
    DateTime ConclusionDate,
    Guid? PositionItemId,
    string? PositionItemName,
    Guid? WorkplaceItemId,
    string? WorkplaceItemName,
    string? OccupationCodeItemId,
    string? OccupationCodeName,
    DateTime StartDate,
    DateTime? TerminationDate,
    int FteNumerator,
    int FteDenominator,
    decimal Salary,
    SalaryType SalaryType,
    ContractType ContractType
);