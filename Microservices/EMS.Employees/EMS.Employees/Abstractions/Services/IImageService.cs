using EMS.Employees.Models;

namespace EMS.Employees.Abstractions.Services;

public interface IImageService
{
    ImageModel? GetImageByName(string name);
}