using System.ComponentModel;
using EMS.Shared.Enums;

namespace EMS.Dto.Education;

[DisplayName("Education")]
public record EducationDto(
    string SchoolName,
    SchoolType Type,
    DateTime Start,
    DateTime End,
    string? Degree,
    string? Occupation);