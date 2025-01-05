using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;
using EMS.Shared.Shared;

namespace EMS.EmployeeRecords.EventBus.Trainings;

public class GetBhpStatusRequestHandler(ITrainingService service)
    : IEventBusRequestHandler<GetBhpStatusRequest, RecordStatus?>
{
    public async Task<RecordStatus?> HandleAsync(GetBhpStatusRequest request)
    {
        return await service.GetBhpStatusAsync(request.EmployeeId);
    }
}