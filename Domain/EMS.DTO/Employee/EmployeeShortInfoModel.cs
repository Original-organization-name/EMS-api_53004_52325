namespace EMS.DTO.Employee;

public record EmployeeShortInfoModel(
    Guid Id,
    string Name, 
    string Surname,
    string? Pesel,
    DateTime EmploymentDate,
    decimal Salary, 
    string SalaryType,
    string ContractType,
    int FteDenominator,
    int FteNumerator);