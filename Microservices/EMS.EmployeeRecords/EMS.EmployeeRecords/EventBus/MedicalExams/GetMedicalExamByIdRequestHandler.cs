using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;

namespace EMS.EmployeeRecords.EventBus.MedicalExams;

public class GetMedicalExamByIdRequestHandler(IMedicalExaminationService service)
    : IEventBusRequestHandler<GetMedicalExamByIdRequest, MedicalExaminationModel?>
{
    public async Task<MedicalExaminationModel?> HandleAsync(GetMedicalExamByIdRequest request)
    {
        return await service.GetById(request.Id);
    }
}