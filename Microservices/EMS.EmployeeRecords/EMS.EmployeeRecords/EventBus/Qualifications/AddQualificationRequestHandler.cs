using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Qualifications;

namespace EMS.EmployeeRecords.EventBus.Qualifications;

public class AddQualificationRequestHandler(IQualificationService service)
    : IEventBusRequestHandler<AddQualificationRequest, QualificationModel>
{
    public async Task<QualificationModel> HandleAsync(AddQualificationRequest request)
    {
        return await service.AddAsync(request.EmployeeId, request.Qualification);
    }
}