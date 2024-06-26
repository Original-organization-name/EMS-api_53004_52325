﻿using EMS.Data.Education.Enums;
using EMS.Data.Models;

namespace EMS.Data.Education;

public class Education : Entity
{
    public required Guid EmployeeId { get; set; }
    
    public required string SchoolName { get; set; }
    public required SchoolType Type { get; set; }
    public required TerminalDatePeriod Period { get; set; }
    public string? Degree { get; set; }
    public string? Occupation { get; set; }
}