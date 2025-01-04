using EMS.Contracts.Domain.Dictionaries;
using EMS.Shared.Enums;
using EMS.Shared.Models;

namespace EMS.Contracts.Domain.Entities;

public class Contract : Entity
{
    public Guid EmployeeId { get; set; }
    
    public required DateTime EmploymentDate { get; set; }
    public required DateTime ConclusionDate { get; set; }

    public Guid? PositionItemId { get; set; }
    public PositionItem? PositionItem { get; set; }
    
    public Guid? WorkplaceItemId { get; set; }
    public WorkplaceItem? WorkplaceItem { get; set; }

    public string? OccupationCodeItemId { get; set; }
    public OccupationCodeItem? OccupationCodeItem { get; set; }

    public required DateTime StartDate { get; set; }
    public DateTime? TerminationDate { get; set; }

    public int FteNumerator { get; set; } = 1;
    public int FteDenominator { get; set; } = 1;

    public required decimal Salary { get; set; }
    public SalaryType SalaryType { get; set; } = SalaryType.Monthly;

    public ContractType ContractType { get; set; } = ContractType.Employment;
    
    public decimal CalcMonthSalary()
    {
        return SalaryType == SalaryType.Monthly
            ? Salary * FteNumerator / FteDenominator
            : Salary * 168 * FteNumerator / FteDenominator;
    }
}