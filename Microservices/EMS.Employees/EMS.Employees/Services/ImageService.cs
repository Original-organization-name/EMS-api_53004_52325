using EMS.Dto.Employees;
using EMS.Employees.Abstractions.Repositories;
using EMS.Employees.Abstractions.Services;

namespace EMS.Employees.Services;

public class ImageService(IImageRepository repositoryManager) : IImageService
{
    public ImageModel? GetImageByName(string name)
    {
        var image = repositoryManager.GetByName(name);
        return image is null ? null :
            new ImageModel(image.ContentType, image.Name, image.Content);
    }
}