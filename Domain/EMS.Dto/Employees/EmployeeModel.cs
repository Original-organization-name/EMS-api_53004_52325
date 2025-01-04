using EMS.Shared.Enums;

namespace EMS.Dto.Employees;

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