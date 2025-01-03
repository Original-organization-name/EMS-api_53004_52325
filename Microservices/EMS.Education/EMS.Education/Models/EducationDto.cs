using System.ComponentModel;
using EMS.Education.Domain.Enums;

namespace EMS.Education.Models;

[DisplayName("Education")]
public record EducationDto(
    string SchoolName,
    SchoolType Type,
    DateTime Start,
    DateTime End,
    string? Degree,
    string? Occupation);