using EMS.Domain.Enums;
using EMS.Domain.Models;

namespace EMS.Employees.Domain.Entities;

public class PaymentMethod : Entity
{
    public PaymentType Type { get; set; }
    public string? BankAccount { get; set; }
}