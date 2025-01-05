using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExamItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.MedicalExamItems;

public class AddMedicalExamItemRequestHandler(IMedicalExamItemService service)
    : IEventBusRequestHandler<AddMedicalExamItemRequest, DictionaryItemModel>
{
    public async Task<DictionaryItemModel> HandleAsync(AddMedicalExamItemRequest request)
    {
        return await service.Add(request.MedicalExam);
    }
}