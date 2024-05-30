using EMS.Data.Contracts.Enums;

namespace EMS.DTO.Employee;

public class EmployeeShortInfoModel
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public string? Pesel { get; init; }
    public DateTime? EmploymentDate { get; init; }
    public DateTime? TerminationDate { get; init; }
    public decimal? Salary { get; init; }
    public SalaryType? SalaryType { get; init; }
    public int? FteDenominator { get; init; }
    public int? FteNumerator { get; init; }
}