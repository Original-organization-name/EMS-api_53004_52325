using EMS.Dto.Contracts;

namespace EMS.Contracts.Abstractions.Services;

public interface IContractService
{
    Task<IReadOnlyList<ContractModel>> GetAllEmployeeContractsAsync(Guid employeeId);
    Task<ContractModel?> GetCurrentOrLatestContractAsync(Guid employeeId);
    Task<ContractModel?> GetByIdAsync(Guid id);
    Task<ContractModel> AddAsync(Guid employeeId, ContractDto contract);
    
    Task<decimal> CountTotalPayrollAsync();
    Task<int> GetActiveContractsCountAsync();
    Task<int> GetExpiresContractsCountAsync();
    Task<IEnumerable<ContractModel>> DeleteEmployeeContractsAsync(Guid employeeId);
}