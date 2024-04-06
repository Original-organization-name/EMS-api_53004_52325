using System.ComponentModel;
using EMS.Data.Employees.Enum;

namespace EMS.Contracts.Employee;

[DisplayName("Employee")]
public record EmployeeDto(
    string Name,
    string Surname,
    string? Pesel,
    string? Nip,
    DateTime? Birthdate,
    Gender? Gender,
    AddressDto? Address,
    List<ContactDto>? Contacts,
    PaymentMethodDto? PaymentMethod);
    