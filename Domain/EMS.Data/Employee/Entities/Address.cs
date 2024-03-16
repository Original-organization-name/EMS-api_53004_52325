
namespace EMS.Data.Employee.Entities;
using EMS.Data.Models;

public class Address : Entity
{
    public string Country { get; set; }
    public string ContryCode { get; set; }
    public string City { get; set; }
    public string District { get; set; } = null;
    public string PostCode { get; set; } = null;
    public string Street { get; set; } = null;
    public string HouseNumber { get; set; } = null;
    public string ApartmentNumber { get; set; } = null;
}
