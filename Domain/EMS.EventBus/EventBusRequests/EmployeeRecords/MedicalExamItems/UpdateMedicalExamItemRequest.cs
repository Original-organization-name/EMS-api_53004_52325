using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExamItems;

public class UpdateMedicalExamItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }
    public DictionaryItemDto MedicalExam { get; set; } = null!;

    public UpdateMedicalExamItemRequest(Guid id, DictionaryItemDto medicalExam)
    {
        Id = id;
        MedicalExam = medicalExam;
    }

    internal UpdateMedicalExamItemRequest()
    {
    }
}