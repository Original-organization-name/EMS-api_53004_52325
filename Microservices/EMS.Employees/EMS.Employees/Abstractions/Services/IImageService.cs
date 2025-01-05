using EMS.Dto.Employees;

namespace EMS.Employees.Abstractions.Services;

public interface IImageService
{
    Task<ImageModel?> GetImageByNameAsync(string name);
}