using EMS.Contracts.Abstractions.Services;
using EMS.Dto.Contracts;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;

namespace EMS.Contracts.EventBus;

public class GetCurrentOrLatestContractRequestHandler(IContractService service)
    : IEventBusRequestHandler<GetCurrentOrLatestContractRequest, ContractModel?>
{
    public async Task<ContractModel?> HandleAsync(GetCurrentOrLatestContractRequest request)
    {
        return await service.GetCurrentOrLatestContractAsync(request.EmployeeId);
    }
}