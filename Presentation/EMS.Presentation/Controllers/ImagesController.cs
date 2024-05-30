using EMS.DTO.Education;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/images")]
public class ImagesController : ControllerBase
{
    private readonly IImageService _service;
    
    public ImagesController(IServiceManager serviceManager)
    {
        _service = serviceManager.ImageService;
    }
    
    [HttpGet("{name}")]
    public async Task<ActionResult<IEnumerable<EducationModel>>> GetImage(string name)
    {
        var image = _service.GetImageByName(name);
        if (image is null)
        {
            return NotFound();
        }
        
        return File(image.Content, image.ContentType);
    }
}