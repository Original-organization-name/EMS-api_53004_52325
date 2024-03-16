using EMS.Data.Models;

namespace EMS.Data.Employee.Entities;

public class Contact : Entity
{
    public string ContactType { get; set; }
    public string ContactData { get; set; }
    public Boolean ContactSort { get; set; } 
    }