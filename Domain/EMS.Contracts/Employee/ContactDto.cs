using EMS.Data.Employee.Enum;

namespace EMS.Contracts.Employee;

public record ContactDto(
    ContactType Type,
    string Data, 
    ContractPrivacy Privacy);