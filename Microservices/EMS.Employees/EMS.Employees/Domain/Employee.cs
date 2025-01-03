using EMS.Shared.Abstractions;
using EMS.Shared.Enums;
using EMS.Shared.Exceptions;
using EMS.Shared.Helpers;
using EMS.Shared.Models;
using EMS.Employees.Domain.Entities;

namespace EMS.Employees.Domain;

public class Employee : Entity, IAggregateRoot
{
    public required string Name { get; set; }
    public required string Surname { get; set; }

    private string? _pesel;
    public string? Pesel
    {
        get => _pesel;
        set
        {
            if (!PeselHelpers.IsValid(value))
            {
                throw new IncorrectPeselFormatException();
            }
            _pesel = value;

            Gender = PeselHelpers.GetGenderFromPesel(_pesel);
            Birthdate = PeselHelpers.GetBirthDate(_pesel);
        }
    }

    public string? Nip { get; set; } 
    public DateTime? Birthdate { get; set; }
    public Gender? Gender { get; set; }

    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    
    public Address? Address { get; set; }
    public PaymentMethod? PaymentMethod { get; set; } 
    
    public string? ImageFileName { get; set; }
}


