using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;

public class GetMedicalExamByIdRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public GetMedicalExamByIdRequest(Guid id)
    {
        Id = id;
    }

    internal GetMedicalExamByIdRequest()
    {
    }
}