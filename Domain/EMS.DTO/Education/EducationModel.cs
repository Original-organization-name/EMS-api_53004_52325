using EMS.Data.Education.Enums;

namespace EMS.DTO.Education;

public record EducationModel(
    Guid Id,
    string SchoolName,
    SchoolType Type,
    DateTime Start,
    DateTime End,
    string? Degree,
    string? Occupation);