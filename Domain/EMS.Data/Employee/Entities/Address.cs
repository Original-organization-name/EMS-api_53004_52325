
namespace EMS.Data.Employee.Entities;
using EMS.Data.Models;

public class Address : Entity
{
    public string? CountryCode { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? PostCode { get; set; }
    public string? Street { get; set; }
    public string? HouseNumber { get; set; }
    public string? ApartmentNumber { get; set; }
}
