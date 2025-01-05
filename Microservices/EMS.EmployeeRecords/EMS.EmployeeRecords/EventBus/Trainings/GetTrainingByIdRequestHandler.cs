using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;

namespace EMS.EmployeeRecords.EventBus.Trainings;

public class GetTrainingByIdRequestHandler(ITrainingService service)
    : IEventBusRequestHandler<GetTrainingByIdRequest, TrainingModel?>
{
    public async Task<TrainingModel?> HandleAsync(GetTrainingByIdRequest request)
    {
        return await service.GetById(request.Id);
    }
}