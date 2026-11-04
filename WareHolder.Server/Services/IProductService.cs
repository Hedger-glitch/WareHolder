using WareHolder.Server.DTOs;

namespace WareHolder.Server.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
