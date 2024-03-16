using EMS.Data.Employee.Enum;

namespace EMS.Contracts.Employee;

public record PaymentMethodDto(
    PaymentType Type,
    string? BankAccount);