using System.ComponentModel;
using EMS.Data.Employees.Enum;

namespace EMS.DTO.Employee;

[DisplayName("Contact")]
public record ContactDto(
    ContactType Type,
    string Data, 
    ContractPrivacy Privacy);