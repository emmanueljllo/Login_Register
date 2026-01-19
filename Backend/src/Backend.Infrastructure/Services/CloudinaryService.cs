using Backend.Application.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Backend.Infrastructure.Services;

public class CloudinaryService : IImageUploader
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IConfiguration configuration)
    {
        var cloudName = configuration["Cloudinary:CloudName"];
        var apiKey = configuration["Cloudinary:ApiKey"];
        var apiSecret = configuration["Cloudinary:ApiSecret"];

        if (string.IsNullOrEmpty(cloudName) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
        {
            // Fallback for demo or throw exception. Ideally prompt user.
            // initializing empty for now, will crash if used without config
            _cloudinary = new Cloudinary(new Account("place", "hold", "er")); 
        }
        else
        {
            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
        }
    }

    public async Task<UploadedImageInfo> UploadAsync(IFormFile file)
    {
        if (file == null || file.Length == 0) 
        {
            Console.WriteLine("CloudinaryService: File is null or empty");
            return null;
        }

        try 
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                Console.WriteLine($"CloudinaryService Error: {uploadResult.Error.Message}");
                throw new Exception($"Cloudinary Error: {uploadResult.Error.Message}");
            }

            Console.WriteLine($"CloudinaryService: Upload successful. PublicId: {uploadResult.PublicId}");

            return new UploadedImageInfo
            {
                Url = uploadResult.SecureUrl.ToString(),
                PublicId = uploadResult.PublicId
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CloudinaryService Exception: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);
        await _cloudinary.DestroyAsync(deleteParams);
    }
}
