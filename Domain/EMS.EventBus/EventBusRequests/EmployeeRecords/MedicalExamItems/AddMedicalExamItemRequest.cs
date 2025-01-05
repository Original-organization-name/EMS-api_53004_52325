using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExamItems;

public class AddMedicalExamItemRequest : IEventBusRequest
{
    public DictionaryItemDto MedicalExam { get; set; } = null!;

    public AddMedicalExamItemRequest(DictionaryItemDto medicalExam)
    {
        MedicalExam = medicalExam;
    }

    internal AddMedicalExamItemRequest()
    {
    }
}