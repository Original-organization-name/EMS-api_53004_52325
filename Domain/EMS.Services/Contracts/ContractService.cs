﻿using EMS.Data.Contracts;
using EMS.DTO.Contracts;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;
using Mapster;

namespace EMS.Services.Contracts;

public class ContractService : IContractService
{
    private readonly IContractRepository _repository;

    public ContractService(IRepositoryManager repositoryManager) => 
        _repository = repositoryManager.ContractRepository;

    public async Task<IReadOnlyList<ContractModel>> GetAllEmployeeContracts(Guid employeeId)
    {
        return _repository.GetAll(employeeId).Select(exam => exam.Adapt<ContractModel>()).ToList();
    }

    public async Task<ContractModel?> GetById(Guid id)
    {
        var contract = await _repository.GetByIdAsync(id);
        return contract.Adapt<ContractModel>();
    }

    public async Task<ContractModel> Add(Guid employeeId, ContractDto contractDto)
    {
        var contract =  contractDto.Adapt<Contract>();
        contract.EmployeeId = employeeId;
        
        contract = await _repository.AddAsync(contract);
        await _repository.SaveChangesAsync();
        
        return contract.Adapt<ContractModel>();
    }
}