﻿using EMS.Data.Shared;
using EMS.DTO.Records;

namespace EMS.Shared.Services;

public interface ITrainingService
{
    Task<IReadOnlyList<TrainingModel>> GetAll(Guid employeeId);
    Task<TrainingModel?> GetById(Guid id);
    Task<TrainingModel> Add(Guid employeeId, TrainingDto training);
    Task<Status?> GetBhpStatus(Guid employeeId);
}