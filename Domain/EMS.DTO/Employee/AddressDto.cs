using System.ComponentModel;

namespace EMS.DTO.Employee;

[DisplayName("Address")]
public record AddressDto(
    string? CountryCode,
    string? City,
    string? District,
    string? PostCode,
    string? Street,
    string? HouseNumber,
    string? FlatNumber);
