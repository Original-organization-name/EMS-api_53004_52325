using System.ComponentModel;
using EMS.Data.Education.Enums;

namespace EMS.DTO.Education;

[DisplayName("Education")]
public record EducationDto(
    string SchoolName,
    SchoolType Type,
    DateTime Start,
    DateTime End,
    string? Degree,
    string? Occupation);