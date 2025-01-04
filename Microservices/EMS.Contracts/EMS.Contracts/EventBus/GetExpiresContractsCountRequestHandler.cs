using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;

namespace EMS.Contracts.EventBus;

public class GetExpiresContractsCountRequestHandler(IContractService service)
    : IEventBusRequestHandler<GetExpiresContractsCountRequest, decimal>
{
    public async Task<decimal> HandleAsync(GetExpiresContractsCountRequest request)
    {
        return await service.GetExpiresContractsCountAsync();
    }
}