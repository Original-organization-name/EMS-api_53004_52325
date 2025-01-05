using EMS.Dto.EmployeeRecords;
using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;

public class AddMedicalExaminationRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public MedicalExaminationDto Examination { get; set; } = null!;
    
    public AddMedicalExaminationRequest(Guid employeeId, MedicalExaminationDto examination)
    {
        EmployeeId = employeeId;
        Examination = examination;
    }

    internal AddMedicalExaminationRequest()
    {
    }
}