using EMS.Shared.Enums;

namespace EMS.Dto.Education;

public record EducationModel(
    Guid Id,
    string SchoolName,
    SchoolType Type,
    DateTime Start,
    DateTime End,
    string? Degree,
    string? Occupation);