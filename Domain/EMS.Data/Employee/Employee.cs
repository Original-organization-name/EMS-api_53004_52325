using EMS.Data.Abstractions;
using EMS.Data.Employee.Entities;
using EMS.Data.Employee.Enum;
using EMS.Data.Models;

namespace EMS.Data.Employee;

public class Employee : Entity, IAggregateRoot
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? Pesel { get; set; } 
    public string? Nip { get; set; } 
    public DateTime? Birthdate { get; set; }
    public Gender? Gender { get; set; }
    
    public Address? Address { get; set; }
    public List<Contact> Contacts { get; set; } = new();
    public PaymentMethod? PaymentMethod { get; set; } 

    public Employee()
    {
    }
}


