using EMS.Domain.Enums;

namespace EMS.Employees.Models;

public record EmployeeModel(
    Guid Id,
    string Name,
    string Surname,
    string? Pesel,
    string? Nip,
    DateTime? Birthdate,
    Gender? Gender,
    AddressDto? Address,
    string? PhoneNumber,
    string? Email,
    PaymentMethodDto? PaymentMethod,
    string? ImageFileName);