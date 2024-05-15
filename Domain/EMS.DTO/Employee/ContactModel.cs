using EMS.Data.Employees.Enum;

namespace EMS.DTO.Employee;

public record ContactModel(
    Guid Id,
    ContactType Type,
    string Data, 
    ContractPrivacy Privacy);