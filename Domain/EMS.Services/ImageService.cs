using EMS.DTO.Employee;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;

namespace EMS.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _repository;

    public ImageService(IRepositoryManager repositoryManager) => 
        _repository = repositoryManager.ImageRepository;

    public ImageModel? GetImageByName(string name)
    {
        var image = _repository.GetByName(name);
        return image is null ? null :
            new ImageModel(image.ContentType, image.Name, image.Content);
    }
}