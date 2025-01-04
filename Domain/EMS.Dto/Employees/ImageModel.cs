namespace EMS.Dto.Employees;

public record ImageModel(
    string ContentType,
    string Name,
    byte[] Content);