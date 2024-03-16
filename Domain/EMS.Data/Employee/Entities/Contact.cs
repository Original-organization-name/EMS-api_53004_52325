using EMS.Data.Employee.Enum;
using EMS.Data.Models;

namespace EMS.Data.Employee.Entities;

public class Contact : Entity
{
    public ContactTypeList TypeList { get; set; }
    public string Data { get; set; }
    public ContactType Type { get; set; }
}