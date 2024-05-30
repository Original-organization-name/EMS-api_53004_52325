using EMS.Data.Contracts.Enums;

namespace EMS.Presentation.ResultModels;

public class EmployeeShortInfoModel
{
    public Guid Id { get; init; }
    public string? ImageName { get; set; }
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public string? Pesel { get; init; }
    public ContractType? ContractType { get; init; }
    public DateTime? EmploymentDate { get; init; }
    public DateTime? TerminationDate { get; init; }
    public decimal? Salary { get; init; }
    public SalaryType? SalaryType { get; init; }
    public int? FteDenominator { get; init; }
    public int? FteNumerator { get; init; }
}