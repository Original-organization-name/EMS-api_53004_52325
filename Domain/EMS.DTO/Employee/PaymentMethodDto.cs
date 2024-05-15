using System.ComponentModel;
using EMS.Data.Employees.Enum;

namespace EMS.DTO.Employee;

[DisplayName("PaymentMethod")]
public record PaymentMethodDto(
    PaymentType Type,
    string? BankAccount);