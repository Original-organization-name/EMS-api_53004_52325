﻿using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.Domain.Entities;
using EMS.Dto.Contracts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EMS.Contracts.Services;

public class ContractService(IContractRepository repository)
    : IContractService
{
    public async Task<IReadOnlyList<ContractModel>> GetAllEmployeeContractsAsync(Guid employeeId)
    {
        return await repository
            .GetAll(employeeId)
            .Select(exam => exam.Adapt<ContractModel>())
            .ToListAsync();
    }

    public ContractModel? GetCurrentOrLatestContract(Guid employeeId)
    {
        var result = repository
            .GetAll(employeeId)
            .Where(x => x.TerminationDate == null || x.TerminationDate >= DateTime.Today)
            .OrderBy(x => x.StartDate)
            .FirstOrDefault();
        
        if(result is null){
            result = repository
                .GetAll(employeeId)
                .Where(x => x.TerminationDate != null || x.TerminationDate < DateTime.Today)
                .OrderByDescending(x => x.TerminationDate)
                .FirstOrDefault();
        }

        return result?.Adapt<ContractModel>();
    }

    public async Task<ContractModel?> GetById(Guid id)
    {
        var contract = await repository.GetByIdAsync(id);
        return contract.Adapt<ContractModel>();
    }

    public async Task<ContractModel> Add(Guid employeeId, ContractDto contractDto)
    {
        var contract =  contractDto.Adapt<Contract>();
        contract.EmployeeId = employeeId;
        
        contract = await repository.AddAsync(contract);
        await repository.SaveChangesAsync();
        
        return contract.Adapt<ContractModel>();
    }

    public async Task<decimal> CountTotalPayrollAsync()
    {
        var currentContract = await repository
            .FindByCondition(x => 
                (x.TerminationDate == null || x.TerminationDate >= DateTime.Today) &&
                x.StartDate <= DateTime.Today)
            .ToListAsync();

        return currentContract.Sum(x => x.CalcMonthSalary());
    }

    public async Task<int> GetActiveContractsCountAsync()
    {
        return await repository
            .FindByCondition(x => x.TerminationDate == null || x.TerminationDate >= DateTime.Today)
            .CountAsync();
    }

    public async Task<int> GetExpiresContractsCountAsync()
    {
        return await repository
            .FindByCondition(x => x.TerminationDate != null && 
                                  x.TerminationDate >= DateTime.Today &&
                                  ((DateTime)x.TerminationDate).AddDays(-14) <= DateTime.Today)
            .CountAsync();
    }
}