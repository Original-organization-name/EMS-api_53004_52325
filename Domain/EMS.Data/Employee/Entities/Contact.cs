using EMS.Data.Employee.Enum;
using EMS.Data.Models;

namespace EMS.Data.Employee.Entities;

public class Contact : Entity
{
    public ContactType Type { get; set; }
    public required string Data { get; set; }
    public ContractPrivacy Privacy { get; set; }
}