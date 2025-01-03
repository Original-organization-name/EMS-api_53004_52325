using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain;
using EMS.EmployeeRecords.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EMS.EmployeeRecords.Services;

public class MedicalExaminationService(IMedicalExaminationRepository repositoryManager) 
    : IMedicalExaminationService
{
    public async Task<IReadOnlyList<MedicalExaminationModel>> GetAllAsync(Guid employeeId)
    {
        return await repositoryManager
            .GetAll(employeeId)
            .Select(exam => exam.Adapt<MedicalExaminationModel>())
            .ToListAsync();
    }

    public async Task<MedicalExaminationModel?> GetById(Guid id)
    {
        var medicalExamination = await repositoryManager.GetByIdAsync(id);
        return medicalExamination.Adapt<MedicalExaminationModel>();
    }

    public async Task<MedicalExaminationModel> Add(Guid employeeId, MedicalExaminationDto medicalExamination)
    {
        var medicalExam = new MedicalExamination()
        {
            EmployeeId = employeeId,
            MedicalExamItemId = medicalExamination.MedicalExamItemId,
            ExecutionDate = medicalExamination.ExecutionDate,
            ExpirationDate = medicalExamination.ExpirationDate,
        };
        
        
        
        medicalExam = await repositoryManager.AddAsync(medicalExam);
        await repositoryManager.SaveChangesAsync();
        return medicalExam.Adapt<MedicalExaminationModel>();
    }
    
}