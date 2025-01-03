namespace EMS.Employees.Models;

public record DashboardAnalytics(
    int TotalEmployeeCount = 0,
    int AddInLastMonth = 0,
    decimal TotalPayroll = 0,
    IEnumerable<EmployeeShortInfoModel>? RecentAddedEmployees = null,
    
    int ActiveContractsCount = 0,
    int ExpiresContractCount = 0,
    List<string>? NearExpiryContract  = null);