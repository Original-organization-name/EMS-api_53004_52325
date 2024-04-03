using EMS.Data.Employees.Enum;
using EMS.Data.Models;

namespace EMS.Data.Employees.Entities;

public class PaymentMethod : Entity
{
    public PaymentType Type { get; set; }
    public string? BankAccount { get; set; }
}