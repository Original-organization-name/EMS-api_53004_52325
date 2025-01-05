using EMS.Dto.Education;
using EMS.Education.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Education;

namespace EMS.Education.EventBus;

public class AddEducationRequestHandler(IEducationService service)
    : IEventBusRequestHandler<AddEducationRequest, EducationModel?>
{
    public async Task<EducationModel?> HandleAsync(AddEducationRequest request)
    {
        return await service.AddAsync(request.EmployeeId, request.Education);
    }
}