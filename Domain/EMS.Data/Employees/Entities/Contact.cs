using EMS.Data.Employees.Enum;
using EMS.Data.Models;

namespace EMS.Data.Employees.Entities;

public class Contact : Entity
{
    public ContactType Type { get; set; }
    public required string Data { get; set; }
    public ContractPrivacy Privacy { get; set; }
}