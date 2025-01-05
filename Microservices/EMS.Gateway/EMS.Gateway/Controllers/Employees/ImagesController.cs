using EMS.Dto.Employees;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.Employees;

[ApiController]
[Route("api/images")]
public class ImagesController(IEventBus bus) : ControllerBase
{
    [HttpGet("{name}")]
    public async Task<IActionResult> GetImage(string name)
    {
        var request = new GetImageRequest(name);
        var image = await bus.RequestAsync<ImageModel>(request);

        if (image is null)
        {
            return NotFound();
        }
        
        return File(image.Content, image.ContentType);
    }
}