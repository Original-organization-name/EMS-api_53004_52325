using EMS.Dto.Employees;
using EMS.Employees.Abstractions.Repositories;
using EMS.Employees.Abstractions.Services;

namespace EMS.Employees.Services;

public class ImageService(IImageRepository repository) : IImageService
{
    public async Task<ImageModel?> GetImageByNameAsync(string name)
    {
        var image = await repository.GetByNameAsync(name);
        return image is null ? null :
            new ImageModel(image.ContentType, image.Name, image.Content);
    }
}