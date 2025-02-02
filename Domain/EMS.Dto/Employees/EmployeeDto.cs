﻿using System.ComponentModel;
using EMS.Shared.Enums;

namespace EMS.Dto.Employees;

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
    