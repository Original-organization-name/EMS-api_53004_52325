﻿using EMS.Shared.Repositories;

namespace EMS.Shared.RepositoryManagers;

public interface IRepositoryManager
{
    IEmployeeRepository EmployeeRepository { get; }
    IMedicalExaminationRepository MedicalExaminationRepository { get; }
    ITrainingRepository TrainingRepository { get; }
    IQualificationRepository QualificationRepository { get; }
}