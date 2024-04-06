using System.ComponentModel;

namespace EMS.Contracts.Employee;

[DisplayName("Address")]
public record AddressDto(
    string? CountryCode,
    string? City,
    string? District,
    string? PostCode,
    string? Street,
    string? HouseNumber,
    string? ApartmentNumber);
