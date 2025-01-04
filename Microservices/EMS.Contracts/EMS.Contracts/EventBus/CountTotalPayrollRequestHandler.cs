using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;

namespace EMS.Contracts.EventBus;

public class CountTotalPayrollRequestHandler(IContractService service)
    : IEventBusRequestHandler<CountTotalPayrollRequest, decimal>
{
    public async Task<decimal> HandleAsync(CountTotalPayrollRequest request)
    {
        return await service.CountTotalPayrollAsync();
    }
}