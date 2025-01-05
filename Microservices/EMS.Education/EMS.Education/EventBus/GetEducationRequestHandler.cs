using EMS.Dto.Education;
using EMS.Education.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Education;

namespace EMS.Education.EventBus;

public class GetEducationRequestHandler(IEducationService service)
    : IEventBusRequestHandler<GetEducationRequest, IEnumerable<EducationModel>>
{
    public async Task<IEnumerable<EducationModel>> HandleAsync(GetEducationRequest request)
    {
        return await service.GetAllEmployeeEducationAsync(request.EmployeeId);
    }
}