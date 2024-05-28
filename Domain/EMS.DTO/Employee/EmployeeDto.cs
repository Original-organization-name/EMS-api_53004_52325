using System.ComponentModel;
using EMS.Data.Employees.Enum;

namespace EMS.DTO.Employee;

[DisplayName("Employee")]
public record EmployeeDto(
    string Name,
    string Surname,
    string? Pesel,
    string? Nip,
    DateTime? Birthdate,
    Gender? Gender,
    AddressDto? Address,
    string? PhoneNumber,
    string? Email,
    PaymentMethodDto? PaymentMethod);
    