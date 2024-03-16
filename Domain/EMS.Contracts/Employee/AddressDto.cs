namespace EMS.Contracts.Employee;

public record AddressDto(
    string? CountryCode,
    string? City,
    string? District,
    string? PostCode,
    string? Street,
    string? HouseNumber,
    string? ApartmentNumber);
