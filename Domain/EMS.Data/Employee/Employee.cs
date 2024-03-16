using EMS.Data.Employee.Entities;
using EMS.Data.Models;

namespace EMS.Data.Employee;

public class Employee : Entity
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? Pesel { get; set; } 

    public Employee(string name, string surname)
    {
    }
}


