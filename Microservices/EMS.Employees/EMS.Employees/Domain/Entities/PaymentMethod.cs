using EMS.Shared.Enums;
using EMS.Shared.Models;

namespace EMS.Employees.Domain.Entities;

public class PaymentMethod : Entity
{
    public PaymentType Type { get; set; }
    public string? BankAccount { get; set; }
}