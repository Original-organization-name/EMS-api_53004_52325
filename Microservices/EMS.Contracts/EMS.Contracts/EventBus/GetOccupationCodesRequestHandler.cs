using EMS.Contracts.Abstractions.Services;
using EMS.Dto.Contracts;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;

namespace EMS.Contracts.EventBus;

public class GetOccupationCodesRequestHandler(IOccupationDictService service)
    : IEventBusRequestHandler<GetOccupationCodesRequest, IEnumerable<OccupationCodeItemModel>>
{
    public async Task<IEnumerable<OccupationCodeItemModel>> HandleAsync(GetOccupationCodesRequest request)
    {
        return await service.GetAll();
    }
}