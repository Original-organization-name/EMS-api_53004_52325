using EMS.Employees.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Employees.Controllers;

[ApiController]
[Route("api/images")]
public class ImagesController(IImageService serviceManager) : ControllerBase
{
    [HttpGet("{name}")]
    public async Task<IActionResult> GetImage(string name)
    {
        var image = serviceManager.GetImageByName(name);
        if (image is null)
        {
            return NotFound();
        }
        
        return File(image.Content, image.ContentType);
    }
}