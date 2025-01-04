using System.ComponentModel;
using EMS.Shared.Enums;

namespace EMS.Dto.Employees;

[DisplayName("PaymentMethod")]
public record PaymentMethodDto(
    PaymentType Type,
    string? BankAccount);