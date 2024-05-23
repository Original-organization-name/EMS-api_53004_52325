using EMS.Data.Experience.Enums;

namespace EMS.DTO.Experience;

public record EducationModel(
    Guid Id,
    string SchoolName,
    SchoolType Type,
    DateTime Start,
    DateTime End,
    string? Degree,
    string? Occupation);