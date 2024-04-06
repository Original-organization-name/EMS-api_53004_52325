using EMS.Contracts.Records;
using EMS.Data.Records;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;
using Mapster;

namespace EMS.Services;

public class MedicalExaminationService : IMedicalExaminationService
{
    private readonly IMedicalExaminationRepository _repository;

    public MedicalExaminationService(IRepositoryManager repositoryManager) => 
        _repository = repositoryManager.MedicalExaminationRepository;

    public async Task<IReadOnlyList<MedicalExaminationModel>> GetAll(Guid employeeId)
    {
        return _repository.GetAll(employeeId).Select(exam => exam.Adapt<MedicalExaminationModel>()).ToList();
    }

    public async Task<MedicalExaminationModel?> GetById(Guid id)
    {
        var medicalExamination = await _repository.GetByIdAsync(id);
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
        
        
        
        medicalExam = await _repository.AddAsync(medicalExam);
        await _repository.SaveChangesAsync();
        return medicalExam.Adapt<MedicalExaminationModel>();
    }
    
}