using EMS.Data.Employees.Enum;

namespace EMS.Contracts.Employee;

public record PaymentMethodDto(
    PaymentType Type,
    string? BankAccount);