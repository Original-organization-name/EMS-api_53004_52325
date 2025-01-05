using EMS.Contracts.Abstractions.Services;
using EMS.Dto.Contracts;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;

namespace EMS.Contracts.EventBus;

public class GetContractByIdRequestHandler(IContractService service)
    : IEventBusRequestHandler<GetContractByIdRequest, ContractModel?>
{
    public async Task<ContractModel?> HandleAsync(GetContractByIdRequest request)
    {
        return await service.GetByIdAsync(request.Id);
    }
}