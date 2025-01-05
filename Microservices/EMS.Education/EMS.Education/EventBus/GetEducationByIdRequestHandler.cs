using EMS.Dto.Education;
using EMS.Education.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Education;

namespace EMS.Education.EventBus;

public class GetEducationByIdRequestHandler(IEducationService service)
    : IEventBusRequestHandler<GetEducationByIdRequest, EducationModel?>
{
    public async Task<EducationModel?> HandleAsync(GetEducationByIdRequest request)
    {
        return await service.GetById(request.Id);
    }
}