﻿using EMS.Data.Employees.Enum;

namespace EMS.DTO.Employee;

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