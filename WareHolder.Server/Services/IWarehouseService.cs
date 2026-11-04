using WareHolder.Server.DTOs;

namespace WareHolder.Server.Services
{
    public interface IWarehouseService
    {
        Task<List<WarehouseDto>> GetAllAsync();
        Task<WarehouseDto?> GetByIdAsync(int id);
        Task<WarehouseDto> CreateAsync(CreateWarehouseDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
