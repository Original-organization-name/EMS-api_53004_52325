using EMS.Dto.Employees;

namespace EMS.Employees.Abstractions.Services;

public interface IImageService
{
    ImageModel? GetImageByName(string name);
}