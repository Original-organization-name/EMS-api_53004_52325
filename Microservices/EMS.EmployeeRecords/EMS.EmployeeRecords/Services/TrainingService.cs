using EMS.Dto.EmployeeRecords;
using EMS.Shared.Extensions;
using EMS.Shared.Shared;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EMS.EmployeeRecords.Services;

public class TrainingService(ITrainingRepository repository) : ITrainingService
{
    public async Task<IReadOnlyList<TrainingModel>> GetAllAsync(Guid employeeId)
    {
        return await repository
            .GetAll(employeeId)
            .Select(exam => exam.Adapt<TrainingModel>())
            .ToListAsync();
    }

    public async Task<TrainingModel?> GetById(Guid id)
    {
        var training = await repository.GetByIdAsync(id);
        return training.Adapt<TrainingModel>();
    }

    public async Task<TrainingModel> AddAsync(Guid employeeId, TrainingDto trainingDto)
    {
        var training = new Training()
        {
            EmployeeId = employeeId,
            TrainingItemId = trainingDto.TrainingItemId,
            ExecutionDate = trainingDto.ExecutionDate,
            ExpirationDate = trainingDto.ExpirationDate,
        };
        
        training = await repository.AddAsync(training);
        await repository.SaveChangesAsync();
        return training.Adapt<TrainingModel>();
    }

    public async Task<RecordStatus?> GetBhpStatusAsync(Guid employeeId)
    {
        return (await repository.GetAll(employeeId)
            .OrderByDescending(x => x.ExpirationDate ?? DateTime.MaxValue)
            .FirstOrDefaultAsync())?.ExpirationDate.GetStatus();
    }

    public async Task<IEnumerable<TrainingModel>> DeleteEmployeeTrainingsAsync(Guid employeeId)
    {
        var trainings = await repository.DeleteByEmployeeIdAsync(employeeId);
        await repository.SaveChangesAsync();
        return trainings
            .Select(exam => exam.Adapt<TrainingModel>())
            .ToList();
    }
}