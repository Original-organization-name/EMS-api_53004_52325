using EMS.Contracts.Abstractions.Services;
using EMS.Dto.Contracts;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;

namespace EMS.Contracts.EventBus;

public class AddContractRequestHandler(IContractService service)
    : IEventBusRequestHandler<AddContractRequest, ContractModel>
{
    public async Task<ContractModel> HandleAsync(AddContractRequest request)
    {
        return await service.AddAsync(request.EmployeeId, request.Contract);
    }
}