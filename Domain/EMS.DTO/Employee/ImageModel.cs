namespace EMS.DTO.Employee;

public record ImageModel(
    string ContentType,
    string Name,
    byte[] Content);