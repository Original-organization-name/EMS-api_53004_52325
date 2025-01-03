namespace EMS.Employees.Models;

public record ImageModel(
    string ContentType,
    string Name,
    byte[] Content);