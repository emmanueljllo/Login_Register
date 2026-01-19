using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly ApplicationDbContext _context;

    public ImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Image>> GetAllAsync()
    {
        return await _context.Images.OrderByDescending(i => i.CreatedAt).ToListAsync();
    }

    public async Task AddAsync(Image image)
    {
        await _context.Images.AddAsync(image);
    }

    public async Task DeleteAsync(int id)
    {
        var image = await GetByIdAsync(id);
        if (image != null)
        {
            _context.Images.Remove(image);
        }
    }

    public async Task<Image?> GetByIdAsync(int id)
    {
        return await _context.Images.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
