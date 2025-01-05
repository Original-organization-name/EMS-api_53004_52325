using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;

namespace EMS.EmployeeRecords.EventBus.MedicalExams;

public class AddMedicalExaminationRequestHandler(IMedicalExaminationService service)
    : IEventBusRequestHandler<AddMedicalExaminationRequest, MedicalExaminationModel>
{
    public async Task<MedicalExaminationModel> HandleAsync(AddMedicalExaminationRequest request)
    {
        return await service.AddAsync(request.EmployeeId, request.Examination);
    }
}