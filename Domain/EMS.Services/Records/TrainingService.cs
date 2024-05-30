using EMS.Data.Extensions;
using EMS.DTO.Records;
using EMS.Data.Records;
using EMS.Data.Shared;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;
using Mapster;

namespace EMS.Services.Records;

public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _repository;

    public TrainingService(IRepositoryManager repositoryManager) => 
        _repository = repositoryManager.TrainingRepository;


    public async Task<IReadOnlyList<TrainingModel>> GetAll(Guid employeeId)
    {
        return _repository.GetAll(employeeId).Select(exam => exam.Adapt<TrainingModel>()).ToList();
    }

    public async Task<TrainingModel?> GetById(Guid id)
    {
        var training = await _repository.GetByIdAsync(id);
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
        
        training = await _repository.AddAsync(training);
        await _repository.SaveChangesAsync();
        return training.Adapt<TrainingModel>();
    }

    public async Task<Status?> GetBhpStatus(Guid employeeId)
    {
        return _repository.GetAll(employeeId)
            .OrderByDescending(x => x.ExpirationDate ?? DateTime.MaxValue)
            .FirstOrDefault()?.ExpirationDate.GetStatus();
    }
}