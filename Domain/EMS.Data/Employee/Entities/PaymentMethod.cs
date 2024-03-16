using EMS.Data.Employee.Enum;
using EMS.Data.Models;

namespace EMS.Data.Employee.Entities;

public class PaymentMethod : Entity
{
    public PaymentType Type { get; set; }
    public string? BankAccount { get; set; }
}