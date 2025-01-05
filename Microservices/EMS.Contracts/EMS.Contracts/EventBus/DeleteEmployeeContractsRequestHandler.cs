using EMS.Contracts.Abstractions.Services;
using EMS.Dto.Contracts;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;

namespace EMS.Contracts.EventBus;

public class DeleteEmployeeContractsRequestHandler(IContractService service)
    : IEventBusRequestHandler<DeleteEmployeeContractsRequest, IEnumerable<ContractModel>>
{
    public async Task<IEnumerable<ContractModel>> HandleAsync(DeleteEmployeeContractsRequest request)
    {
        return await service.DeleteEmployeeContractsAsync(request.EmployeeId);
    }
}