using EMS.DTO.Contracts;

namespace EMS.Shared.Services;

public interface IContractService
{
    Task<IReadOnlyList<ContractModel>> GetAllEmployeeContracts(Guid employeeId);
    ContractModel? GetCurrentOrLatestContract(Guid employeeId);
    Task<ContractModel?> GetById(Guid id);
    Task<ContractModel> Add(Guid employeeId, ContractDto contract);
    
    decimal CountTotalPayroll();
}