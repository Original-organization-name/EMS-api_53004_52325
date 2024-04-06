using System.ComponentModel;
using EMS.Data.Employees.Enum;

namespace EMS.Contracts.Employee;

[DisplayName("PaymentMethod")]
public record PaymentMethodDto(
    PaymentType Type,
    string? BankAccount);