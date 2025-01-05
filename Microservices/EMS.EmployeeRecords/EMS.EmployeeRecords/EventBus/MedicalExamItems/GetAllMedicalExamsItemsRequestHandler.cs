using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExamItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.MedicalExamItems;

public class GetAllMedicalExamsItemsRequestHandler(IMedicalExamItemService service)
    : IEventBusRequestHandler<GetAllMedicalExamsItemsRequest, IReadOnlyList<DictionaryItemModel>>
{
    public async Task<IReadOnlyList<DictionaryItemModel>> HandleAsync(GetAllMedicalExamsItemsRequest request)
    {
        return await service.GetAllAsync();
    }
}