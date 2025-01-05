using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EMS.EmployeeRecords.Services;

public class MedicalExaminationService(IMedicalExaminationRepository repository) 
    : IMedicalExaminationService
{
    public async Task<IReadOnlyList<MedicalExaminationModel>> GetAllAsync(Guid employeeId)
    {
        return await repository
            .GetAll(employeeId)
            .Select(exam => exam.Adapt<MedicalExaminationModel>())
            .ToListAsync();
    }

    public async Task<MedicalExaminationModel?> GetById(Guid id)
    {
        var medicalExamination = await repository.GetByIdAsync(id);
        return medicalExamination.Adapt<MedicalExaminationModel>();
    }

    public async Task<MedicalExaminationModel> AddAsync(Guid employeeId, MedicalExaminationDto medicalExamination)
    {
        var medicalExam = new MedicalExamination()
        {
            EmployeeId = employeeId,
            MedicalExamItemId = medicalExamination.MedicalExamItemId,
            ExecutionDate = medicalExamination.ExecutionDate,
            ExpirationDate = medicalExamination.ExpirationDate,
        };
        
        
        
        medicalExam = await repository.AddAsync(medicalExam);
        await repository.SaveChangesAsync();
        return medicalExam.Adapt<MedicalExaminationModel>();
    }

    public async Task<IEnumerable<MedicalExaminationModel>> DeleteEmployeeExamsAsync(Guid employeeId)
    {
        var exams = await repository.DeleteByEmployeeIdAsync(employeeId);
        await repository.SaveChangesAsync();
        return exams
            .Select(exam => exam.Adapt<MedicalExaminationModel>())
            .ToList();
    }
}