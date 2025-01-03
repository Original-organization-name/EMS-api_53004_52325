using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain;
using EMS.EmployeeRecords.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EMS.EmployeeRecords.Services;

public class QualificationService(IQualificationRepository repositoryManager) : IQualificationService
{
    public async Task<IReadOnlyList<QualificationModel>> GetAllAsync(Guid employeeId)
    {
        return await repositoryManager
            .GetAll(employeeId)
            .Select(exam => exam.Adapt<QualificationModel>())
            .ToListAsync();
    }

    public async Task<QualificationModel?> GetById(Guid id)
    {
        var qualification = await repositoryManager.GetByIdAsync(id);
        return qualification.Adapt<QualificationModel>();
    }

    public async Task<QualificationModel> Add(Guid employeeId, QualificationDto qualificationDto)
    {
        var qualification = new Qualification()
        {
            EmployeeId = employeeId,
            QualificationItemId = qualificationDto.QualificationItemId,
            ExpirationDate = qualificationDto.ExpirationDate,
        };
        
        qualification = await repositoryManager.AddAsync(qualification);
        await repositoryManager.SaveChangesAsync();
        return qualification.Adapt<QualificationModel>();
    }
}