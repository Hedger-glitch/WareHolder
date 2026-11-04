using WareHolder.Server.DTOs;

namespace WareHolder.Server.Services
{
    public interface IShelfService
    {
        Task<List<ShelfDto>> GetAllAsync();
        Task<ShelfDto?> GetByIdAsync(int id);
        Task<ShelfDto> CreateAsync(CreateShelfDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
