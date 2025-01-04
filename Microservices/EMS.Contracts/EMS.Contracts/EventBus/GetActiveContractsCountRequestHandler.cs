using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;

namespace EMS.Contracts.EventBus;

public class GetActiveContractsCountRequestHandler(IContractService service)
    : IEventBusRequestHandler<GetActiveContractsCountRequest, decimal>
{
    public async Task<decimal> HandleAsync(GetActiveContractsCountRequest request)
    {
        return await service.GetActiveContractsCountAsync();
    }
}