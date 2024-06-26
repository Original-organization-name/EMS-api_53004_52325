﻿using EMS.Services.Contracts;
using EMS.Services.Dictionaries;
using EMS.Services.Experience;
using EMS.Services.Records;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;

namespace EMS.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmployeeService> _lazyEmployeeService;
    private readonly Lazy<IMedicalExaminationService> _lazyMedicalExaminationService;
    private readonly Lazy<IQualificationService> _lazyQualificationService;
    private readonly Lazy<ITrainingService> _lazyTrainingService;
    private readonly Lazy<IEducationService> _lazyEducationService;
    private readonly Lazy<IOccupationDictService> _lazyOccupationDictService;
    private readonly Lazy<IContractService> _lazyContractService;
    private readonly Lazy<IImageService> _lazyImageService;
        
    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyEmployeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager));
        _lazyMedicalExaminationService = new Lazy<IMedicalExaminationService>(() => new MedicalExaminationService(repositoryManager));
        _lazyQualificationService = new Lazy<IQualificationService>(() => new QualificationService(repositoryManager));
        _lazyTrainingService = new Lazy<ITrainingService>(() => new TrainingService(repositoryManager));
        _lazyEducationService = new Lazy<IEducationService>(() => new EducationService(repositoryManager));
        _lazyOccupationDictService = new Lazy<IOccupationDictService>(() => new OccupationDictService(repositoryManager));
        _lazyContractService = new Lazy<IContractService>(() => new ContractService(repositoryManager));
        _lazyImageService = new Lazy<IImageService>(() => new ImageService(repositoryManager));
    }

    public IEmployeeService EmployeeService => _lazyEmployeeService.Value;
    public IMedicalExaminationService MedicalExaminationService => _lazyMedicalExaminationService.Value;
    public IQualificationService QualificationService => _lazyQualificationService.Value;
    public ITrainingService TrainingService => _lazyTrainingService.Value;
    public IEducationService EducationService => _lazyEducationService.Value;
    public IOccupationDictService OccupationDictService => _lazyOccupationDictService.Value;
    public IContractService ContractService => _lazyContractService.Value;
    public IImageService ImageService => _lazyImageService.Value;
}