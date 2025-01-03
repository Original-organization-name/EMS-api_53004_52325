using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.Domain.Entities;
using EMS.Contracts.Models;
using Mapster;

namespace EMS.Contracts.Services;

public class ContractService(IContractRepository repository)
    : IContractService
{
    public async Task<IReadOnlyList<ContractModel>> GetAllEmployeeContracts(Guid employeeId)
    {
        return repository.GetAll(employeeId).Select(exam => exam.Adapt<ContractModel>()).ToList();
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

    public decimal CountTotalPayroll()
    {
        var currentContract = repository
            .FindByCondition(x => 
                (x.TerminationDate == null || x.TerminationDate >= DateTime.Today) &&
                x.StartDate <= DateTime.Today)
            .ToList();

        return currentContract.Sum(x => x.CalcMonthSalary());
    }

    public int GetActiveContractsCount()
    {
        return repository
            .FindByCondition(x => x.TerminationDate == null || x.TerminationDate >= DateTime.Today)
            .Count();
    }

    public int GetExpiresContractsCount()
    {
        return repository
            .FindByCondition(x => x.TerminationDate != null && 
                                  x.TerminationDate >= DateTime.Today &&
                                  ((DateTime)x.TerminationDate).AddDays(-14) <= DateTime.Today)
            .Count();
    }
}