using Microsoft.EntityFrameworkCore;
using WareHolder.Server.Data;
using WareHolder.Server.DTOs;
using WareHolder.Server.Models;

namespace WareHolder.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _db.Products.ToListAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                SupplierId = p.SupplierId,
            }).ToList();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                SupplierId = product.SupplierId
            };
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                SupplierId = dto.SupplierId
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                SupplierId = product.SupplierId
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return false;

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
