using Microsoft.EntityFrameworkCore;
using WareHolder.Server.Data;
using WareHolder.Server.DTOs;
using WareHolder.Server.Models;

namespace WareHolder.Server.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _db;

        public InventoryService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<InventoryDto>> GetAllAsync()
        {
            var inventories = await _db.Inventories.ToListAsync();

            return inventories.Select(i => new InventoryDto
            {
                Id = i.Id,
                ShelfId = i.ShelfId,
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList();
        }

        public async Task<InventoryDto> AddOrUpdateAsync(CreateInventoryDto dto)
        {
            var shelf = await _db.Shelves.FindAsync(dto.ShelfId);
            var product = await _db.Products.FindAsync(dto.ProductId);

            if (shelf == null) throw new ArgumentException("Error: shelf not found");

            if (product == null) throw new ArgumentException("Error: product not found");

            if (shelf.SupplierId != product.SupplierId)
            {
                throw new ArgumentException("Error: shelf and product owned by different suppliers");
            }
            var existingInventory = await _db.Inventories
                    .FirstOrDefaultAsync(i => i.ShelfId == dto.ShelfId && i.ProductId == dto.ProductId);

            if (existingInventory != null)
            {
                existingInventory.Quantity += dto.Quantity;
                await _db.SaveChangesAsync();

                return new InventoryDto
                {
                    Id = existingInventory.Id,
                    ShelfId = existingInventory.ShelfId,
                    ProductId = existingInventory.ProductId,
                    Quantity = existingInventory.Quantity
                };
            }

            var newInventory = new Inventory
            {
                ShelfId = dto.ShelfId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            _db.Inventories.Add(newInventory);
            await _db.SaveChangesAsync();

            return new InventoryDto
            {
                Id = newInventory.Id,
                ShelfId = newInventory.ShelfId,
                ProductId = newInventory.ProductId,
                Quantity = newInventory.Quantity
            };
        }
    }
}
