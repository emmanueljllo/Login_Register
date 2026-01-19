using Backend.Application.DTOs;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IImageUploader _imageUploader;

    public ImageService(IImageRepository imageRepository, IImageUploader imageUploader)
    {
        _imageRepository = imageRepository;
        _imageUploader = imageUploader;
    }

    public async Task<IEnumerable<ImageDto>> GetAllImagesAsync()
    {
        var images = await _imageRepository.GetAllAsync();
        return images.Select(i => new ImageDto
        {
            Id = i.Id,
            Url = i.Url,
            Title = i.Title
        });
    }

    public async Task<ImageDto> UploadImageAsync(IFormFile file, string title)
    {
        var uploadResult = await _imageUploader.UploadAsync(file);

        var image = new Image
        {
            Url = uploadResult.Url,
            PublicId = uploadResult.PublicId,
            Title = title,
            CreatedAt = DateTime.UtcNow
        };

        await _imageRepository.AddAsync(image);
        await _imageRepository.SaveChangesAsync();

        return new ImageDto
        {
            Id = image.Id,
            Url = image.Url,
            Title = image.Title
        };
    }
}
