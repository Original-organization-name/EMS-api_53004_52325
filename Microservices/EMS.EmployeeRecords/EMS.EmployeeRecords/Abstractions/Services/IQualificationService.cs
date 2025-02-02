﻿using EMS.Dto.EmployeeRecords;

namespace EMS.EmployeeRecords.Abstractions.Services;

public interface IQualificationService
{
    Task<IReadOnlyList<QualificationModel>> GetAllAsync(Guid employeeId);
    Task<QualificationModel?> GetById(Guid id);
    Task<QualificationModel> AddAsync(Guid employeeId, QualificationDto qualificationDto);
}