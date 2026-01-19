using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface IImageRepository
{
    Task<IEnumerable<Image>> GetAllAsync();
    Task AddAsync(Image image);
    Task DeleteAsync(int id);
    Task<Image?> GetByIdAsync(int id);
    Task SaveChangesAsync();
}
