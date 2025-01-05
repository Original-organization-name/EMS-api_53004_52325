using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords;

namespace EMS.EmployeeRecords.EventBus.Trainings;

public class AddTrainingRequestHandler(ITrainingService service)
    : IEventBusRequestHandler<AddTrainingRequest, TrainingModel>
{
    public async Task<TrainingModel> HandleAsync(AddTrainingRequest request)
    {
        return await service.AddAsync(request.EmployeeId, request.Training);
    }
}