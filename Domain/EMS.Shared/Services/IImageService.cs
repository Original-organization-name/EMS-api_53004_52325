using EMS.DTO.Employee;

namespace EMS.Shared.Services;

public interface IImageService
{
    ImageModel? GetImageByName(string name);
}