using Backend.Application.DTOs;
using Backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImagesController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ImageDto>>> GetAll()
    {
        var images = await _imageService.GetAllImagesAsync();
        return Ok(images);
    }

    [HttpPost("upload")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ImageDto>> Upload([FromForm] IFormFile file, [FromForm] string title)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded");
        }

        var result = await _imageService.UploadImageAsync(file, title);
        return Ok(result);
    }
}
