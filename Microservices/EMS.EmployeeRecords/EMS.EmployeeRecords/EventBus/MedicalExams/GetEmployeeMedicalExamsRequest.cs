using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;

namespace EMS.EmployeeRecords.EventBus.MedicalExams;

public class GetEmployeeMedicalExamsRequestHandler(IMedicalExaminationService service)
    : IEventBusRequestHandler<GetEmployeeMedicalExamsRequest, IEnumerable<MedicalExaminationModel>>
{
    public async Task<IEnumerable<MedicalExaminationModel>> HandleAsync(GetEmployeeMedicalExamsRequest request)
    {
        return await service.GetAllAsync(request.EmployeeId);
    }
}