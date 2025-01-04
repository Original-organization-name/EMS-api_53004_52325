using System.ComponentModel;

namespace EMS.Dto.Employees;

[DisplayName("Address")]
public record AddressDto(
    string? CountryCode,
    string? City,
    string? District,
    string? PostCode,
    string? Street,
    string? HouseNumber,
    string? FlatNumber);
