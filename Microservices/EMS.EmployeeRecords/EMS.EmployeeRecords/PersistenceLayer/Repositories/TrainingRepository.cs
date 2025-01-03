﻿using EMS.Domain.Repositories;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMS.EmployeeRecords.PersistenceLayer.Repositories;

public class TrainingRepository : BaseRepository<RecordsDbContext, Training>, ITrainingRepository
{
    public TrainingRepository(RecordsDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IQueryable<Training> GetAll()
    {
        return base.GetAll().Include(item => item.TrainingItem);
    }

    public IQueryable<Training> GetAll(Guid employeeId)
    {
        return GetAll().Where(item => item.EmployeeId == employeeId);
    }
}