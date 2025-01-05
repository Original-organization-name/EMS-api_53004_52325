using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;

namespace EMS.EmployeeRecords.EventBus.MedicalExams;

public class DeleteEmployeeMedicalExamsRequestHandler(IMedicalExaminationService service)
    : IEventBusRequestHandler<DeleteEmployeeMedicalExamsRequest, IEnumerable<MedicalExaminationModel>>
{
    public async Task<IEnumerable<MedicalExaminationModel>> HandleAsync(DeleteEmployeeMedicalExamsRequest request)
    {
        return await service.DeleteEmployeeExamsAsync(request.EmployeeId);
    }
}