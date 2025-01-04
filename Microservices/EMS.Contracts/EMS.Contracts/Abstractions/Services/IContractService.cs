using EMS.Dto.Contracts;

namespace EMS.Contracts.Abstractions.Services;

public interface IContractService
{
    Task<IReadOnlyList<ContractModel>> GetAllEmployeeContractsAsync(Guid employeeId);
    ContractModel? GetCurrentOrLatestContract(Guid employeeId);
    Task<ContractModel?> GetById(Guid id);
    Task<ContractModel> Add(Guid employeeId, ContractDto contract);
    
    Task<decimal> CountTotalPayrollAsync();
    Task<int> GetActiveContractsCountAsync();
    Task<int> GetExpiresContractsCountAsync();
}