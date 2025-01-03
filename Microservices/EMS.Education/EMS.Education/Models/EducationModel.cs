using EMS.Education.Domain.Enums;

namespace EMS.Education.Models;

public record EducationModel(
    Guid Id,
    string SchoolName,
    SchoolType Type,
    DateTime Start,
    DateTime End,
    string? Degree,
    string? Occupation);