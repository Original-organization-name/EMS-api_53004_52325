using EMS.Data.Models;

namespace EMS.Data.Employee.Entities;

public class PaymentMethod : Entity
{
    public string PaymentWay { get; set; }
    public string? BankAccount { get; set; }
}