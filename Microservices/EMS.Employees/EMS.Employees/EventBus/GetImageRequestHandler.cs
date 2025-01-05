using EMS.Dto.Employees;
using EMS.Employees.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Employees;

namespace EMS.Employees.EventBus;

public class GetImageRequestHandler(IImageService service)
    : IEventBusRequestHandler<GetImageRequest, ImageModel?>
{
    public async Task<ImageModel?> HandleAsync(GetImageRequest request)
    {
       return await service.GetImageByNameAsync(request.ImageName);
    }
}