namespace Backend.Application.DTOs;

public class ImageDto
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}

public class UploadImageRequest
{
    public string Title { get; set; } = string.Empty;
    // Note: IFormFile is binding in Controller, passed to Service strictly as Stream or wrapped. 
    // Usually Service takes IFormFile directly in .NET for simplicity, though pure DDD prefers Stream. 
    // We will pass IFormFile to Service for pragmatism.
}
