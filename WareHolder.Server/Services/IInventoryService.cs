using WareHolder.Server.DTOs;

namespace WareHolder.Server.Services
{
    public interface IInventoryService
    {
        Task<List<InventoryDto>> GetAllAsync();
        Task<InventoryDto> AddOrUpdateAsync(CreateInventoryDto dto);
    }
}
