using EMS.Contracts.Abstractions.Services;
using EMS.Dto.Contracts;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;

namespace EMS.Contracts.EventBus;

public class GetContractsRequestHandler(IContractService service)
    : IEventBusRequestHandler<GetContractsRequest, IEnumerable<ContractModel>>
{
    public async Task<IEnumerable<ContractModel>> HandleAsync(GetContractsRequest request)
    {
        return await service.GetAllEmployeeContractsAsync(request.EmployeeId);
    }
}