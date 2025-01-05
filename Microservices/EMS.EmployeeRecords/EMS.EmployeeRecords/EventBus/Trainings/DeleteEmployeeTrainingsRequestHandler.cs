using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;

namespace EMS.EmployeeRecords.EventBus.Trainings;

public class DeleteEmployeeTrainingsRequestHandler(ITrainingService service)
    : IEventBusRequestHandler<DeleteEmployeeTrainingsRequest, IEnumerable<TrainingModel>>
{
    public async Task<IEnumerable<TrainingModel>> HandleAsync(DeleteEmployeeTrainingsRequest request)
    {
        return await service.DeleteEmployeeTrainingsAsync(request.EmployeeId);
    }
}