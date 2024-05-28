using EMS.Data.Education;
using EMS.DTO.Education;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;
using Mapster;

namespace EMS.Services.Experience;

public class EducationService : IEducationService
{
    private readonly IEducationRepository _repository;

    public EducationService(IRepositoryManager repositoryManager) => 
        _repository = repositoryManager.EducationRepository;

    public async Task<IReadOnlyList<EducationModel>> GetAllEmployeeEducation(Guid employeeId)
    {
        return _repository.GetAllEmployeeEducation(employeeId).Select(exam => exam.Adapt<EducationModel>()).ToList();
    }

    public async Task<EducationModel?> GetById(Guid id)
    {
        var education = await _repository.GetByIdAsync(id);
        return education.Adapt<EducationModel>();
    }

    public async Task<EducationModel> Add(Guid employeeId, EducationDto educationDto)
    {
        var education = (employeeId, educationDto).Adapt<Education>();
        education = await _repository.AddAsync(education);
        await _repository.SaveChangesAsync();
        return education.Adapt<EducationModel>();
    }
}