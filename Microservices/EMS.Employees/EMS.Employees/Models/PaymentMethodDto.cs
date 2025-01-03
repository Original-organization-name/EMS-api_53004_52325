using System.ComponentModel;
using EMS.Shared.Enums;

namespace EMS.Employees.Models;

[DisplayName("PaymentMethod")]
public record PaymentMethodDto(
    PaymentType Type,
    string? BankAccount);