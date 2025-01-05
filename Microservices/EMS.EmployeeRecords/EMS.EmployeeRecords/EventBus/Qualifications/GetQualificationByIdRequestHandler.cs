using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Qualifications;

namespace EMS.EmployeeRecords.EventBus.Qualifications;

public class GetQualificationByIdRequestHandler(IQualificationService service)
    : IEventBusRequestHandler<GetQualificationByIdRequest, QualificationModel?>
{
    public async Task<QualificationModel?> HandleAsync(GetQualificationByIdRequest request)
    {
        return await service.GetById(request.Id);
    }
}