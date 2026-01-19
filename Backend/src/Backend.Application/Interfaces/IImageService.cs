using Backend.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Interfaces;

public interface IImageService
{
    Task<IEnumerable<ImageDto>> GetAllImagesAsync();
    Task<ImageDto> UploadImageAsync(IFormFile file, string title);
    // Task DeleteImageAsync(int id); // Optional for now
}
