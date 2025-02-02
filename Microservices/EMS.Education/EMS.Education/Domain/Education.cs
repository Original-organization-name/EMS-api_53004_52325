﻿using EMS.Shared.Enums;
using EMS.Shared.Models;

namespace EMS.Education.Domain;

public class Education : Entity
{
    public required Guid EmployeeId { get; set; }
    
    public required string SchoolName { get; set; }
    public required SchoolType Type { get; set; }
    public required TerminalDatePeriod Period { get; set; }
    public string? Degree { get; set; }
    public string? Occupation { get; set; }
}