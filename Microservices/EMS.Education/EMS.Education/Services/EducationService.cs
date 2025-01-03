using EMS.Education.Abstractions.Repositories;
using EMS.Education.Abstractions.Services;
using EMS.Education.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EMS.Education.Services;

public class EducationService(IEducationRepository repository)
    : IEducationService
{
    public async Task<IReadOnlyList<EducationModel>> GetAllEmployeeEducationAsync(Guid employeeId)
    {
        return await repository
            .GetAllEmployeeEducation(employeeId)
            .Select(exam => exam.Adapt<EducationModel>())
            .ToListAsync();
    }

    public async Task<EducationModel?> GetById(Guid id)
    {
        var education = await repository.GetByIdAsync(id);
        return education.Adapt<EducationModel>();
    }

    public async Task<EducationModel> Add(Guid employeeId, EducationDto educationDto)
    {
        var education = (employeeId, educationDto).Adapt<Domain.Education>();
        education = await repository.AddAsync(education);
        await repository.SaveChangesAsync();
        return education.Adapt<EducationModel>();
    }
}