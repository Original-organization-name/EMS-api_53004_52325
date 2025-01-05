using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Qualifications;

namespace EMS.EmployeeRecords.EventBus.Qualifications;

public class GetEmployeeQualificationsRequestHandler(IQualificationService service)
    : IEventBusRequestHandler<GetEmployeeQualificationsRequest, IEnumerable<QualificationModel>>
{
    public async Task<IEnumerable<QualificationModel>> HandleAsync(GetEmployeeQualificationsRequest request)
    {
        return await service.GetAllAsync(request.EmployeeId);
    }
}