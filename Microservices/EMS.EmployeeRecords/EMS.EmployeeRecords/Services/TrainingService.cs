using EMS.Dto.EmployeeRecords;
using EMS.Shared.Extensions;
using EMS.Shared.Shared;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EMS.EmployeeRecords.Services;

public class TrainingService(ITrainingRepository repositoryManager) : ITrainingService
{
    public async Task<IReadOnlyList<TrainingModel>> GetAllAsync(Guid employeeId)
    {
        return await repositoryManager
            .GetAll(employeeId)
            .Select(exam => exam.Adapt<TrainingModel>())
            .ToListAsync();
    }

    public async Task<TrainingModel?> GetById(Guid id)
    {
        var training = await repositoryManager.GetByIdAsync(id);
        return training.Adapt<TrainingModel>();
    }

    public async Task<TrainingModel> Add(Guid employeeId, TrainingDto trainingDto)
    {
        var training = new Training()
        {
            EmployeeId = employeeId,
            TrainingItemId = trainingDto.TrainingItemId,
            ExecutionDate = trainingDto.ExecutionDate,
            ExpirationDate = trainingDto.ExpirationDate,
        };
        
        training = await repositoryManager.AddAsync(training);
        await repositoryManager.SaveChangesAsync();
        return training.Adapt<TrainingModel>();
    }

    public async Task<RecordStatus?> GetBhpStatusAsync(Guid employeeId)
    {
        return (await repositoryManager.GetAll(employeeId)
            .OrderByDescending(x => x.ExpirationDate ?? DateTime.MaxValue)
            .FirstOrDefaultAsync())?.ExpirationDate.GetStatus();
    }
}