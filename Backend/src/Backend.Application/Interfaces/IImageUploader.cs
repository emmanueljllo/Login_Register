using Microsoft.AspNetCore.Http;

namespace Backend.Application.Interfaces;

public interface IImageUploader
{
    Task<UploadedImageInfo> UploadAsync(IFormFile file);
    Task DeleteAsync(string publicId);
}

public class UploadedImageInfo
{
    public string Url { get; set; } = string.Empty;
    public string PublicId { get; set; } = string.Empty;
}
