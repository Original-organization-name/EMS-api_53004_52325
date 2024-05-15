using EMS.DTO.Employee;

namespace EMS.Presentation.ReslutModels;

public record DashboardAnalytics(
    int TotalEmployeeCount = 0,
    int AddInLastMonth = 0,
    decimal TotalPayroll = 0,
    List<EmployeeShortInfoModel>? RecentAddedEmployees = null,
    List<string>? NearExpiryContract  = null);