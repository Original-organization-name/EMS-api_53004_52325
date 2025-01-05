using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExamItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.MedicalExamItems;

public class UpdateMedicalExamItemRequestHandler(IMedicalExamItemService service)
    : IEventBusRequestHandler<UpdateMedicalExamItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(UpdateMedicalExamItemRequest request)
    {
        return await service.Update(request.Id, request.MedicalExam);
    }
}