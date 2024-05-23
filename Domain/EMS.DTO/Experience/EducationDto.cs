using EMS.Data.Experience.Enums;
using EMS.Data.Models;

namespace EMS.DTO.Experience;

public record EducationDto(
    string SchoolName,
    SchoolType Type,
    DateTime Start,
    DateTime End,
    string? Degree,
    string? Occupation);