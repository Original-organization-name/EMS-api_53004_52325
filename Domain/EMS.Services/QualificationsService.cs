using EMS.Contracts.Records;
using EMS.Data.Records;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;
using Mapster;

namespace EMS.Services;

public class QualificationService : IQualificationService
{
    private readonly IQualificationRepository _repository;

    public QualificationService(IRepositoryManager repositoryManager) => 
        _repository = repositoryManager.QualificationRepository;


    public async Task<IReadOnlyList<QualificationModel>> GetAll(Guid employeeId)
    {
        return _repository.GetAll(employeeId).Select(exam => exam.Adapt<QualificationModel>()).ToList();
    }

    public async Task<QualificationModel?> GetById(Guid id)
    {
        var qualification = await _repository.GetByIdAsync(id);
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
        
        qualification = await _repository.AddAsync(qualification);
        await _repository.SaveChangesAsync();
        return qualification.Adapt<QualificationModel>();
    }
}