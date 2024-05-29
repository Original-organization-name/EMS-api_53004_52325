using EMS.Data.Contracts.Enums;
using EMS.Data.Dictionaries;
using EMS.Data.Employees;
using EMS.Data.Models;

namespace EMS.Data.Contracts;

public class Contract : Entity
{
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    
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
}