using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;

namespace EMS.EmployeeRecords.EventBus.Trainings;

public class GetEmployeeTrainingsRequestHandler(ITrainingService service)
    : IEventBusRequestHandler<GetEmployeeTrainingsRequest, IEnumerable<TrainingModel>>
{
    public async Task<IEnumerable<TrainingModel>> HandleAsync(GetEmployeeTrainingsRequest request)
    {
        return await service.GetAllAsync(request.EmployeeId);
    }
}