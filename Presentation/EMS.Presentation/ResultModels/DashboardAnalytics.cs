using EMS.DTO.Employee;

namespace EMS.Presentation.ResultModels;

public record DashboardAnalytics(
    int TotalEmployeeCount = 0,
    int AddInLastMonth = 0,
    decimal TotalPayroll = 0,
    IEnumerable<EmployeeShortInfoModel>? RecentAddedEmployees = null,
    List<string>? NearExpiryContract  = null);